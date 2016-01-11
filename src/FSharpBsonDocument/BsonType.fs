namespace FSharpBsonDocument

type BsonType =
    | Double = 1
    | String = 2
    | Document = 3
    | Array = 4
    | Binary = 5
    | Undefined = 6
    | ObjectId = 7
    | Boolean = 8
    | DateTime = 9
    | Null = 10
    | RegularExpression = 11
    | JavaScript = 13
    | JavaScriptWithScope = 15
    | Int32 = 16
    | Timestamp = 17
    | Int64 = 18
    | MaxKey = 127
    | MinKey = 255

