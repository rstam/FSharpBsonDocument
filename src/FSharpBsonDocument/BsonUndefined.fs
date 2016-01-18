namespace FSharpBsonDocument

type BsonUndefined =
    struct
        // members
        override this.ToString () =
            "undefined"

        // interfaces
        interface IBsonUndefined with
            member this.Type = BsonType.Undefined
    end
