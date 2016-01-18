namespace FSharpBsonDocument

type BsonBinary =
    struct
        // fields
        val _subType : BinarySubType
        val _value : byte[]

        // constructors
        new (subType : BinarySubType, value : byte[]) =
            { _subType = subType; _value = value }

        // members
        override this.ToString () =
            let subType = this._subType.ToString ()
            let hex = Hex.ToHex this._value
            "{ \"$type\" : " + subType + ", \"$hex\" : \"" + hex + "\" }"

        // interfaces
        interface IBsonBinary with
            member this.Type = BsonType.Double
            member this.SubType = this._subType
            member this.Value = this._value
    end
