namespace FSharpBsonDocument

type BsonNull =
    struct
        // members
        override this.ToString () =
            "null"

        // interfaces
        interface IBsonNull with
            member this.Type = BsonType.Null
    end

