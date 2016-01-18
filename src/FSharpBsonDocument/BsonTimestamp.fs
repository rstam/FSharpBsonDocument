namespace FSharpBsonDocument

type BsonTimestamp =
    struct
        // fields
        val _value : int64

        // constructors
        new (value : int64) =
            { _value = value }

        new (timestamp : int, increment : int) =
            let value = ((int64 timestamp) <<< 32) ||| ((int64 increment) &&& 0xffffffffL)
            { _value = value }

        // members
        override this.ToString () =
            let timestamp = (this :> IBsonTimestamp).Timestamp.ToString ()
            let increment = (this :> IBsonTimestamp).Increment.ToString ()
            "{ \"$timestamp\" : { \"t\" : " + timestamp + ", \"i\" : " + increment + " } }"

        // interfaces
        interface IBsonTimestamp with
            member this.Type = BsonType.Timestamp
            member this.Value = this._value
            member this.Timestamp = int (this._value >>> 32)
            member this.Increment = int this._value
    end
