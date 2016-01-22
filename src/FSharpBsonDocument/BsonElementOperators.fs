module BsonExtensions

open System
open System.Collections.Generic
open FSharpBsonDocument

let (!@) (value : obj) =
    match value with
    | :? IEnumerable<IBsonValue> as items -> BsonArray(items) :> IBsonValue
    | :? (byte[]) as value -> BsonBinary(BinarySubType.Binary, value) :> IBsonValue
    | :? bool as value -> BsonBoolean(value) :> IBsonValue
    | :? DateTime as value -> BsonDateTime(value) :> IBsonValue
    | :? IEnumerable<IBsonElement> as elements -> BsonDocument(elements) :> IBsonValue
    | :? double as value -> BsonDouble(value) :> IBsonValue
    | :? int as value -> BsonInt32(value) :> IBsonValue
    | :? int64 as value -> BsonInt64(value) :> IBsonValue
    | :? ObjectId as value -> BsonObjectId(value) :> IBsonValue
    | :? string as value -> BsonString(value) :> IBsonValue
    | _ -> raise (InvalidCastException())

let (@=) (name : string) (value : obj) =
    BsonElement(name, !@ value) :> IBsonElement
