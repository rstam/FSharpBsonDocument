namespace FSharpBsonDocument

type BsonDouble =
    struct
        // fields
        val _value : double

        // constructors
        new (value : double) =
            { _value = value }

        // members
        override this.ToString () =
            let s = this._value.ToString()
            if s.IndexOfAny([| '.'; 'e'; 'E' |]) = -1 then s + ".0" else s

        // interfaces
        interface IBsonDouble with
            member this.Type = BsonType.Double
            member this.Value = this._value
    end
