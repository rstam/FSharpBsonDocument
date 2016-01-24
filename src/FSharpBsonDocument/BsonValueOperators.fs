module BsonValueOperators

open System
open System.Collections
open System.Collections.Generic
open FSharpBsonDocument

let (!@) (value : obj) =
    match value with
    | :? IBsonValue as value -> value
    | :? (byte[]) as value -> BsonBinary(BinarySubType.Binary, value) :> IBsonValue
    | :? bool as value -> BsonBoolean(value) :> IBsonValue
    | :? DateTime as value -> BsonDateTime(value) :> IBsonValue
    | :? double as value -> BsonDouble(value) :> IBsonValue
    | :? int as value -> BsonInt32(value) :> IBsonValue
    | :? int64 as value -> BsonInt64(value) :> IBsonValue
    | :? ObjectId as value -> BsonObjectId(value) :> IBsonValue
    | :? string as value -> BsonString(value) :> IBsonValue
    | :? IEnumerable<IBsonElement> as elements -> BsonDocument(elements) :> IBsonValue
    | :? IEnumerable<IBsonValue> as items -> BsonArray(items) :> IBsonValue
    | :? IEnumerable<byte[]> as items -> BsonArray(items |> Seq.map (fun i -> BsonBinary(BinarySubType.Binary, i) :> IBsonValue)) :> IBsonValue
    | :? IEnumerable<bool> as items -> BsonArray(items |> Seq.map (fun i -> BsonBoolean(i) :> IBsonValue)) :> IBsonValue
    | :? IEnumerable<DateTime> as items -> BsonArray(items |> Seq.map (fun i -> BsonDateTime(i) :> IBsonValue)) :> IBsonValue
    | :? IEnumerable<double> as items -> BsonArray(items |> Seq.map (fun i -> BsonDouble(i) :> IBsonValue)) :> IBsonValue
    | :? IEnumerable<int> as items -> BsonArray(items |> Seq.map (fun i -> BsonInt32(i) :> IBsonValue)) :> IBsonValue
    | :? IEnumerable<int64> as items -> BsonArray(items |> Seq.map (fun i -> BsonInt64(i) :> IBsonValue)) :> IBsonValue
    | :? IEnumerable<ObjectId> as items -> BsonArray(items |> Seq.map (fun i -> BsonObjectId(i) :> IBsonValue)) :> IBsonValue
    | :? IEnumerable<string> as items -> BsonArray(items |> Seq.map (fun i -> BsonString(i) :> IBsonValue)) :> IBsonValue
    | _ -> raise (InvalidCastException())

let (@=) (name : string) (value : obj) =
    BsonElement(name, !@ value) :> IBsonElement
