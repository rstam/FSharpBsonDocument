namespace FSharpBsonDocument

type BsonObjectId =
    struct
        // fields
        val _value : ObjectId

        // constructors
        new (value : ObjectId) =
            { _value = value }

        // members
        override this.ToString () =
            let hex = Hex.ToHex (this._value.ToByteArray ())
            "ObjectId(\"" + hex + "\")"

        // interfaces
        interface IBsonObjectId with
            member this.Type = BsonType.ObjectId
            member this.Value = this._value
    end
