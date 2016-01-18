namespace FSharpBsonDocument

type BsonMinKey =
    struct
        // members
        override this.ToString () =
            "{ \"$minKey\" : 1 }"

        // interfaces
        interface IBsonMinKey with
            member this.Type = BsonType.MinKey
    end

