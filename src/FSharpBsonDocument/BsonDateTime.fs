namespace FSharpBsonDocument

type BsonDateTime =
    struct
        // fields
        val _value : int64

        // constructors
        new(value : int64) =
            { _value = value }

        // members
        override this.ToString() =
            "{ \"$date\" : { \"$numberLong\" : \"" + this._value.ToString() + "\" } }"

        // interfaces
        interface IBsonDateTime with
            member this.Type = BsonType.DateTime
            member this.Value = this._value
    end
