namespace FSharpBsonDocument

open System
open System.Collections
open System.Collections.Generic

type BsonArray =
    struct
        // fields
        val _items : List<IBsonValue>

        // constructors
        new (items : seq<IBsonValue>) =
            { _items = new List<IBsonValue> (items) }

        // interfaces
        interface IBsonValue with
            member this.Type = BsonType.Array

        interface IBsonArray with
            member this.Count = this._items.Count

            member this.Array index =
                let value = (this :> IBsonArray).[index]
                value :?> IBsonArray

            member this.Boolean index =
                let value = (this :> IBsonArray).[index]
                (value :?> IBsonBoolean).Value

            member this.DateTime index =
                let value = (this :> IBsonArray).[index]
                Bson.toDateTime (value :?> IBsonDateTime)

            member this.Document index =
                let value = (this :> IBsonArray).[index]
                value :?> IBsonDocument

            member this.Double index =
                let value = (this :> IBsonArray).[index]
                (value :?> IBsonDouble).Value

            member this.Int32 index =
                let value = (this :> IBsonArray).[index]
                (value :?> IBsonInt32).Value

            member this.Int64 index =
                let value = (this :> IBsonArray).[index]
                (value :?> IBsonInt64).Value

            member this.Item
                with get index =
                    this._items.[index]

            member this.ObjectId index =
                let value = (this :> IBsonArray).[index]
                (value :?> IBsonObjectId).Value

            member this.String index =
                let value = (this :> IBsonArray).[index]
                (value :?> IBsonString).Value

        interface IEnumerable with
            member this.GetEnumerator () =
                this._items.GetEnumerator () :> IEnumerator

        interface IEnumerable<IBsonValue> with
            member this.GetEnumerator () =
                this._items.GetEnumerator () :> IEnumerator<IBsonValue>
    end