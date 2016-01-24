namespace FSharpBsonDocument

open System
open System.Collections
open System.Collections.Generic

type BsonDocument =
    struct
        // fields
        val _elements : List<IBsonElement>

        // constructors
        new(elements : seq<IBsonElement>) =
            { _elements = List<IBsonElement> elements }

        new(nameValuePairs : seq<string * IBsonValue>) =
            let elements = nameValuePairs |> Seq.map (fun (name, value) -> BsonElement(name, value) :> IBsonElement)
            { _elements = List<IBsonElement> elements }

        private new(elements : List<IBsonElement>) =
            { _elements = elements }

        // members
        override this.ToString() =
            let elements = this._elements |> Seq.map (fun e -> e.ToString()) |> Seq.toArray
            if elements.Length = 0 then "{}" else "{ " + String.Join(", ", elements) + " }"

        // interfaces
        interface IBsonValue with
            member this.Type = BsonType.Document

        interface IBsonDocument with
            member this.Count = this._elements.Count
            member this.IsEmpty = this._elements.Count = 0

            member this.Array name =
                let value = (this :> IBsonDocument).[name]
                value :?> IBsonArray

            member this.Boolean name =
                let value = (this :> IBsonDocument).[name]
                (value :?> IBsonBoolean).Value

            member this.ContainsKey name =
                this._elements |> Seq.exists (fun e -> e.Name = name)

            member this.DateTime name =
                let value = (this :> IBsonDocument).[name]
                Bson.toDateTime (value :?> IBsonDateTime)

            member this.Document name =
                let value = (this :> IBsonDocument).[name]
                value :?> IBsonDocument

            member this.Double name =
                let value = (this :> IBsonDocument).[name]
                (value :?> IBsonDouble).Value

            member this.Int32 name =
                let value = (this :> IBsonDocument).[name]
                (value :?> IBsonInt32).Value

            member this.Int64 name =
                let value = (this :> IBsonDocument).[name]
                (value :?> IBsonInt64).Value

            member this.Item
                with get name =
                    this._elements |> Seq.pick (fun e -> if e.Name = name then Some e.Value else None)

            member this.Item
                with get index =
                    this._elements.[index]

            member this.ObjectId name =
                let value = (this :> IBsonDocument).[name]
                (value :?> IBsonObjectId).Value

            member this.Remove name =
                let elements = List<IBsonElement> this._elements
                ignore (elements.RemoveAll(fun e -> e.Name = name))
                BsonDocument elements :> IBsonDocument

            member this.Remove names =
                let elements = List<IBsonElement> this._elements
                for name in names do
                    ignore (elements.RemoveAll(fun e -> e.Name = name))
                BsonDocument elements :> IBsonDocument

            member this.String name =
                let value = (this :> IBsonDocument).[name]
                (value :?> IBsonString).Value

            member this.TryFind name =
                this._elements |> Seq.tryPick (fun e -> if e.Name = name then Some e.Value else None)

            member this.With(name, value) =
                let elements = List<IBsonElement> this._elements
                let element = BsonElement(name, value) :> IBsonElement
                let index = elements |> Seq.tryFindIndex (fun e -> e.Name = name)
                match index with
                    | Some index -> elements.[index] <- element
                    | None -> elements.Add(element)
                BsonDocument elements :> IBsonDocument

            member this.With(nameValuePairs : IEnumerable<string * IBsonValue>) =
                let elements = List<IBsonElement> this._elements
                for (name, value) in nameValuePairs do
                    let element = BsonElement(name, value) :> IBsonElement
                    let index = elements |> Seq.tryFindIndex (fun e -> e.Name = name)
                    match index with
                        | Some index -> elements.[index] <- element
                        | None -> elements.Add(element)
                BsonDocument elements :> IBsonDocument

        interface IEnumerable with
            member this.GetEnumerator() =
                this._elements.GetEnumerator() :> IEnumerator

        interface IEnumerable<IBsonElement> with
            member this.GetEnumerator() =
                this._elements.GetEnumerator() :> IEnumerator<IBsonElement>
    end