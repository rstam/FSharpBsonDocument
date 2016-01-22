namespace FSharpBsonDocument

type BsonBinary =
    class
        // fields
        val _subType : BinarySubType
        val _value : byte[]

        // constructors
        new(subType : BinarySubType, value : byte[]) =
            { _subType = subType; _value = value }

        // members
        override this.ToString() =
            sprintf "{ \"$type\" : %i, \"$hex\" : \"%s\" }" (int this._subType) (Hex.ToHex(this._value))

        // interfaces
        interface IBsonBinary with
            member this.Type = BsonType.Binary
            member this.SubType = this._subType
            member this.Value = this._value
    end
