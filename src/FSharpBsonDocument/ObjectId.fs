namespace FSharpBsonDocument

open System
open System.Diagnostics
open System.Threading

type ObjectId =
    struct
        // fields
        val _a : int
        val _b : int
        val _c : int

        // static properties
        static member Empty =
            ObjectIdHelper.Empty

        // static methods
        static member NewId() =
            let timestamp = ObjectIdHelper.ComputeTimestamp()
            let machine = ObjectIdHelper.Machine
            let pid = ObjectIdHelper.Pid
            let increment = ObjectIdHelper.ComputeIncrement()
            new ObjectId(timestamp, machine, pid, increment)

        static member Parse(value : string) =
            let bytes = Hex.ToByteArray(value)
            new ObjectId(bytes)

        // constructors
        new(a : int, b : int, c : int) =
            { _a = a; _b = b; _c = c }

        new(bytes : byte[]) =
            let a = (int bytes.[0] <<< 24) ||| (int bytes.[1] <<< 16) ||| (int bytes.[2] <<< 8) ||| (int bytes.[3])
            let b = (int bytes.[4] <<< 24) ||| (int bytes.[5] <<< 16) ||| (int bytes.[6] <<< 8) ||| (int bytes.[7])
            let c = (int bytes.[8] <<< 24) ||| (int bytes.[9] <<< 16) ||| (int bytes.[10] <<< 8) ||| (int bytes.[11])
            { _a = a; _b = b; _c = c }

        new(timestamp : int, machine : int, pid : int16, increment : int) =
            let a = timestamp
            let b = (machine <<< 8) ||| ((int pid &&& 0xff00) >>> 8)
            let c = (int pid <<< 24) ||| (increment &&& 0x00ffffff)
            { _a = a; _b = b; _c = c }

        // properties
        member this.A =
            this._a

        member this.B =
            this._b

        member this.C =
            this._c

        member this.Increment =
            this._c &&& 0x00ffffff

        member this.Machine =
            (this._b >>> 8) &&& 0x00ffffff

        member this.Pid =
            int16 ((this._b <<< 8) ||| ((this._c >>> 24) &&& 0xff))

        member this.Timestamp =
            this._a

        // methods
        member this.ToByteArray() =
            [|
                byte (this._a >>> 24);
                byte (this._a >>> 16);
                byte (this._a >>> 8);
                byte this._a;
                byte (this._b >>> 24);
                byte (this._b >>> 16);
                byte (this._b >>> 8);
                byte this._b;
                byte (this._c >>> 24);
                byte (this._c >>> 16);
                byte (this._c >>> 8);
                byte this._c
            |]

        override this.ToString() =
            Hex.ToHex(this.ToByteArray())
    end

and private ObjectIdHelper() =
    class
        // static fields
        static let __empty = new ObjectId(0, 0, 0)
        static let mutable __increment = (new Random()).Next()
        static let __machine = ObjectIdHelper.ComputeMachine()
        static let __pid = int16 (Process.GetCurrentProcess().Id)
    
        // static properties
        static member Empty =
            __empty
        
        static member Machine =
            __machine

        static member Pid =
            __pid
    
        // static methods
        static member ComputeIncrement() =
            let increment = Interlocked.Increment(&__increment)
            increment &&& 0x00ffffff

        static member ComputeMachine() =
            let hash = Environment.MachineName.GetHashCode()
            let id = AppDomain.CurrentDomain.Id
            (hash + id) &&& 0xffffff

        static member ComputeTimestamp() =
            let now = DateTime.UtcNow
            let unixEpoch = DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            int (now - unixEpoch).TotalSeconds
    end
