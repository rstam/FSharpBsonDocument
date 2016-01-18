namespace FSharpBsonDocument

type BsonMaxKey =
    struct
        // members
        override this.ToString () =
            "{ \"$maxKey\" : 1 }"

        // interfaces
        interface IBsonMaxKey with
            member this.Type = BsonType.MaxKey
    end

