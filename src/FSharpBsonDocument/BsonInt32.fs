namespace FSharpBsonDocument

type BsonInt32 =
    struct
        // fields
        val _value : int

        // constructors
        new(value : int) =
            { _value = value }

        // members
        override this.ToString() =
            this._value.ToString()

        // interfaces
        interface IBsonInt32 with
            member this.Type = BsonType.Int32
            member this.Value = this._value
    end
