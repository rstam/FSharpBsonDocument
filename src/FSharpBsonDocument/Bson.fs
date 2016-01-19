//namespace FSharpBsonDocument

module Bson

open System
open FSharpBsonDocument

let (|Binary|_|) (value : IBsonValue) =
    match value with
        | :? IBsonBinary as value -> Some value
        | _ -> None

let (|Boolean|_|) (value : IBsonValue) =
    match value with
        | :? IBsonBoolean as value -> Some value.Value
        | _ -> None

let (|DateTime|_|) (value : IBsonValue) =
    match value with
        | :? IBsonDateTime as value -> Some value
        | _ -> None

let (|Double|_|) (value : IBsonValue) =
    match value with
        | :? IBsonDouble as value -> Some value.Value
        | _ -> None

let (|Int32|_|) (value : IBsonValue) =
    match value with
        | :? IBsonInt32 as value -> Some value.Value
        | _ -> None

let (|Int64|_|) (value : IBsonValue) =
    match value with
        | :? IBsonInt64 as value -> Some value.Value
        | _ -> None

let (|JavaScript|_|) (value : IBsonValue) =
    match value with
        | :? IBsonJavaScript as value -> Some value
        | _ -> None

let (|JavaScriptWithScope|_|) (value : IBsonValue) =
    match value with
        | :? IBsonJavaScriptWithScope as value -> Some value
        | _ -> None

let (|MaxKey|_|) (value : IBsonValue) =
    match value with
        | :? IBsonMaxKey -> Some ()
        | _ -> None

let (|MinKey|_|) (value : IBsonValue) =
    match value with
        | :? IBsonMinKey -> Some ()
        | _ -> None

let (|Null|_|) (value : IBsonValue) =
    match value with
        | :? IBsonNull -> Some ()
        | _ -> None

let (|ObjectId|_|) (value : IBsonValue) =
    match value with
        | :? IBsonObjectId as value -> Some value.Value
        | _ -> None

let (|RegularExpression|_|) (value : IBsonValue) =
    match value with
        | :? IBsonRegularExpression as value -> Some value
        | _ -> None

let (|String|_|) (value : IBsonValue) =
    match value with
        | :? IBsonString as value -> Some value.Value
        | _ -> None

let (|Timestamp|_|) (value : IBsonValue) =
    match value with
        | :? IBsonString as value -> Some value
        | _ -> None

let (|Undefined|_|) (value : IBsonValue) =
    match value with
        | :? IBsonUndefined -> Some ()
        | _ -> None

let toBoolean (value : IBsonValue) =
    match value with
        | Boolean value -> value
        | Double value -> value <> 0.0
        | Int32 value -> value <> 0
        | Int64 value -> value <> 0L
        | Null -> false
        | String value -> value <> null
        | Undefined -> false
        | _ -> true

let toDateTime (value : IBsonDateTime) : DateTime =
    raise (NotImplementedException())

let toInt32 (value : IBsonValue) =
    match value with
        | Double value -> int value
        | Int32 value -> value
        | Int64 value -> int value
        | String value -> Int32.Parse(value)
        | _ -> raise (InvalidCastException())

let toInt64 (value : IBsonValue) =
    match value with
        | Double value -> int64 value
        | Int32 value -> int64 value
        | Int64 value -> value
        | String value -> Int64.Parse(value)
        | _ -> raise (InvalidCastException())
