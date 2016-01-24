namespace FSharpBsonDocument

open System
open System.Collections.Generic

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

type BinarySubType = 
    | Binary = 0
    | UuidLegacy = 3
    | UuidStandard = 4
    | MD5 = 5

type IBsonValue =
    interface
        // properties
        abstract Type : BsonType with get
    end

type IBsonBinary =
    interface
        inherit IBsonValue

        // properties
        abstract SubType : BinarySubType with get
        abstract Value : byte[] with get
    end

type IBsonBoolean =
    interface
        inherit IBsonValue

        // properties
        abstract Value : bool with get
    end

type IBsonDateTime =
    interface
        inherit IBsonValue

        // properties
        abstract Value : int64 with get
    end

type IBsonDouble =
    interface
        inherit IBsonValue

        // properties
        abstract Value : double with get
    end

type IBsonInt32 =
    interface
        inherit IBsonValue

        // properties
        abstract Value : int with get
    end

type IBsonInt64 =
    interface
        inherit IBsonValue

        // properties
        abstract Value : int64 with get
    end

type IBsonMaxKey =
    interface
        inherit IBsonValue
    end

type IBsonMinKey =
    interface
        inherit IBsonValue
    end

type IBsonNull =
    interface
        inherit IBsonValue
    end

type IBsonObjectId =
    interface
        inherit IBsonValue

        // properties
        abstract Value : ObjectId with get
    end

type IBsonRegularExpression =
    interface
        inherit IBsonValue

        // properties
        abstract Pattern : string with get
        abstract Options : string with get
    end

type IBsonString =
    interface
        inherit IBsonValue

        // properties
        abstract Value : string with get
    end

type IBsonTimestamp =
    interface
        inherit IBsonValue

        // properties
        abstract Timestamp : int with get
        abstract Increment : int with get
        abstract Value : int64 with get
    end

type IBsonUndefined =
    interface
        inherit IBsonValue
    end

type IBsonElement =
    interface
        // properties
        abstract Name : string with get
        abstract Value : IBsonValue with get
    end

type IBsonDocument =
    interface
        inherit IBsonValue
        inherit IEnumerable<IBsonElement>

        // properties
        abstract Count : int with get
        abstract Item : int -> IBsonElement with get
        abstract Item : string -> IBsonValue with get
        abstract IsEmpty : bool with get

        // methods
        abstract Array : string -> IBsonArray
        abstract Boolean : string -> bool
        abstract ContainsKey : string -> bool
        abstract DateTime : string -> DateTime
        abstract Document : string -> IBsonDocument
        abstract Double : string -> double
        abstract Int32 : string -> int
        abstract Int64 : string -> int64
        abstract ObjectId : string -> ObjectId
        abstract Remove : string -> IBsonDocument
        abstract Remove : IEnumerable<string> -> IBsonDocument
        abstract String : string -> string
        abstract TryFind : string -> IBsonValue option
        abstract With : string * IBsonValue -> IBsonDocument
        abstract With : IEnumerable<string * IBsonValue> -> IBsonDocument
    end

and IBsonArray =
    interface
        inherit IBsonValue
        inherit IEnumerable<IBsonValue>

        // properties
        abstract Count : int with get
        abstract Item : int -> IBsonValue with get

        // methods
        abstract Array : int -> IBsonArray
        abstract Boolean : int -> bool
        abstract DateTime : int -> DateTime
        abstract Document : int -> IBsonDocument
        abstract Double : int -> double
        abstract Int32 : int -> int
        abstract Int64 : int -> int64
        abstract ObjectId : int -> ObjectId
        abstract String : int -> string
    end

type IBsonJavaScript =
    interface
        inherit IBsonValue

        // properties
        abstract Code : string with get
    end

type IBsonJavaScriptWithScope =
    interface
        inherit IBsonJavaScript

        // properties
        abstract Scope : IBsonDocument with get
    end

