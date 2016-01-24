namespace FSharpBsonDocumentTests

open System
open BsonValueOperators
open FSharpBsonDocument
open Xunit

type BsonValueOperatorsTests =
    class
        new() =
            {}

        [<Fact>]
        member this.``!at with BsonValue should return expected result``() =
            let value = BsonInt32(1) :> IBsonValue
            let result = !@ value
            Assert.Same(value, result)

        [<Fact>]
        member this.``!at with byte[] should return expected result``() =
            let value = [| 1uy; 2uy; 3uy |]
            let result = !@ value
            Assert.Equal(BinarySubType.Binary, (result :?> IBsonBinary).SubType)
            Assert.Equal<byte>(value, (result :?> IBsonBinary).Value)

        [<Fact>]
        member this.``!at with bool should return expected result``() =
            let value = true
            let result = !@ value
            Assert.Equal(value, (result :?> IBsonBoolean).Value)

        [<Fact>]
        member this.``!at with double should return expected result``() =
            let value = 1.5
            let result = !@ value
            Assert.Equal(value, (result :?> IBsonDouble).Value)

        [<Fact>]
        member this.``!at with int should return expected result``() =
            let value = 1
            let result = !@ value
            Assert.Equal(value, (result :?> IBsonInt32).Value)


        [<Fact>]
        member this.``!at with int64 should return expected result``() =
            let value = 1L
            let result = !@ value
            Assert.Equal(value, (result :?> IBsonInt64).Value)

        [<Fact>]
        member this.``!at with ObjectId should return expected result``() =
            let value = ObjectId.NewId()
            let result = !@ value
            Assert.Equal(value, (result :?> IBsonObjectId).Value)

        [<Fact>]
        member this.``!at with string should return expected result``() =
            let value = "abc"
            let result = !@ value
            Assert.Equal(value, (result :?> IBsonString).Value)

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<IBsonElement> should return expected result``(count : int) =
            let elements = Seq.init count (fun i -> let name = string(char (97 + i), 1) in BsonElement(name, !@ i) :> IBsonElement)
            let result = !@ elements
            let document = result :?> IBsonDocument
            Assert.Equal(count, document.Count)
            for i in 0 .. (count - 1) do
                let element = document.[i]
                let name = string(char(97 + i), 1)
                Assert.Equal(name, element.Name)
                Assert.Equal(i, (element.Value :?> IBsonInt32).Value)              

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<IBsonValue> should return expected result``(count : int) =
            let items = Seq.init count (fun i -> !@ i) |> Seq.toArray
            let result = !@ items
            let array = result :?> IBsonArray
            Assert.Equal(count, array.Count)
            for i in 0 .. (count - 1) do
                let item = array.[i]
                Assert.Same(items.[i], item)               

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<byte[]> should return expected result``(count : int) =
            let items = Seq.init count (fun i -> [| byte i |]) |> Seq.toArray
            let result = !@ items
            let array = result :?> IBsonArray
            Assert.Equal(count, array.Count)
            for i in 0 .. (count - 1) do
                let item = array.[i]
                Assert.Same(items.[i], (item :?> IBsonBinary).Value)               

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<bool> should return expected result``(count : int) =
            let items = Seq.init count (fun i -> i % 2 = 0) |> Seq.toArray
            let result = !@ items
            let array = result :?> IBsonArray
            Assert.Equal(count, array.Count)
            for i in 0 .. (count - 1) do
                let item = array.[i]
                Assert.Equal(items.[i], (item :?> IBsonBoolean).Value)               

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<double> should return expected result``(count : int) =
            let items = Seq.init count (fun i -> double i) |> Seq.toArray
            let result = !@ items
            let array = result :?> IBsonArray
            Assert.Equal(count, array.Count)
            for i in 0 .. (count - 1) do
                let item = array.[i]
                Assert.Equal(items.[i], (item :?> IBsonDouble).Value)               

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<int> should return expected result``(count : int) =
            let items = Seq.init count (fun i -> i) |> Seq.toArray
            let result = !@ items
            let array = result :?> IBsonArray
            Assert.Equal(count, array.Count)
            for i in 0 .. (count - 1) do
                let item = array.[i]
                Assert.Equal(items.[i], (item :?> IBsonInt32).Value)               

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<int64> should return expected result``(count : int) =
            let items = Seq.init count (fun i -> int64 i) |> Seq.toArray
            let result = !@ items
            let array = result :?> IBsonArray
            Assert.Equal(count, array.Count)
            for i in 0 .. (count - 1) do
                let item = array.[i]
                Assert.Equal(items.[i], (item :?> IBsonInt64).Value)               

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<ObjectId> should return expected result``(count : int) =
            let items = Seq.init count (fun i -> ObjectId.NewId()) |> Seq.toArray
            let result = !@ items
            let array = result :?> IBsonArray
            Assert.Equal(count, array.Count)
            for i in 0 .. (count - 1) do
                let item = array.[i]
                Assert.Equal(items.[i], (item :?> IBsonObjectId).Value)               

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        [<InlineData(3)>]
        member this.``!at with IEnumerable<string> should return expected result``(count : int) =
            let items = Seq.init count (fun i -> string(char(97 + i), 1)) |> Seq.toArray
            let result = !@ items
            let array = result :?> IBsonArray
            Assert.Equal(count, array.Count)
            for i in 0 .. (count - 1) do
                let item = array.[i]
                Assert.Equal(items.[i], (item :?> IBsonString).Value)    
                
        [<Fact>]
        member this.``!at with invalid value should throw``() =
            Assert.Throws<InvalidCastException>(fun () -> ignore (!@ Guid.NewGuid()))   
            
        [<Fact>]
        member this.``atEqual with int value should return expected result``() =
            let result = "abc" @= 1
            Assert.Equal("abc", result.Name)
            Assert.Equal(1, (result.Value :?> IBsonInt32).Value)
            
        [<Fact>]
        member this.``atEqual with string value should return expected result``() =
            let result = "abc" @= "def"
            Assert.Equal("abc", result.Name)
            Assert.Equal("def", (result.Value :?> IBsonString).Value)
   end
