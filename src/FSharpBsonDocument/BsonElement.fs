namespace FSharpBsonDocument

type BsonElement =
    struct
        // fields
        val _name : string
        val _value : IBsonValue

        // constructors
        new(name : string, value : IBsonValue) =
            { _name = name; _value = value }

        // members
        override this.ToString() =
            let name = this._name.Replace("\"", "\"\"")
            let value = this._value.ToString()
            "\"" + name + "\" : " + value

        // interfaces
        interface IBsonElement with
            member this.Name = this._name
            member this.Value = this._value
    end
