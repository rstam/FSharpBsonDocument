namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type ObjectIdTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData(1)>]
        [<InlineData(-1)>]
        member this.``A should return expected result``(a : int) =
            let subject = ObjectId(a, 0, 0)
            let result = subject.A
            Assert.Equal(a, result)

        [<Theory>]
        [<InlineData(1)>]
        [<InlineData(-1)>]
        member this.``B should return expected result``(b : int) =
            let subject = ObjectId(0, b, 0)
            let result = subject.B
            Assert.Equal(b, result)

        [<Theory>]
        [<InlineData(1)>]
        [<InlineData(-1)>]
        member this.``C should return expected result``(c : int) =
            let subject = ObjectId(0, 0, c)
            let result = subject.C
            Assert.Equal(c, result)

        [<Theory>]
        [<InlineData(0, 0, 0)>]
        [<InlineData(1, 2, 3)>]
        [<InlineData(-1, -2, -3)>]
        member this.``constructor with a, b, c should initialize instance``(a : int, b : int, c : int) =
            let result = ObjectId(a, b, c)
            Assert.Equal(a, result.A)
            Assert.Equal(b, result.B)
            Assert.Equal(c, result.C)

        [<Theory>]
        [<InlineData("0102030405060708090a0b0c", 0x01020304, 0x05060708, 0x090a0b0c)>]
        [<InlineData("f1f2f3f4f5f6f7f8f9fafbfc", 0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc)>]
        member this.``constructor with bytes should initialize instance``(bytes : string, a : int, b : int, c : int) =
            let bytes = Hex.ToByteArray(bytes)
            let result = ObjectId(bytes)
            Assert.Equal(a, result.A)
            Assert.Equal(b, result.B)
            Assert.Equal(c, result.C)

        [<Theory>]
        [<InlineData(0x01020304, 0x00050607, 0x0809s, 0x000a0b0c, 0x01020304, 0x05060708, 0x090a0b0c)>]
        [<InlineData(0xf1f2f3f4, 0x00f5f6f7, 0xf8f9s, 0x00fafbfc, 0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc)>]
        member this.``constructor with timestamp, machine, pid, increment should initialize instance``(timestamp : int, machine : int, pid : int16, increment : int, a : int, b : int, c : int) =
            let result = ObjectId(timestamp, machine, pid, increment)
            Assert.Equal(a, result.A)
            Assert.Equal(b, result.B)
            Assert.Equal(c, result.C)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = ObjectId()
            Assert.Equal(0, result.A)
            Assert.Equal(0, result.B)
            Assert.Equal(0, result.C)

        [<Fact>]
        member this.``Empty returns expected result``() =
            let result = ObjectId.Empty
            Assert.Equal(0, result.A)
            Assert.Equal(0, result.B)
            Assert.Equal(0, result.C)

        [<Theory>]
        [<InlineData(0x01020304, 0x05060708, 0x090a0b0c, 0x000a0b0c)>]
        [<InlineData(0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc, 0x00fafbfc)>]
        member this.``Increment should return expected result``(a : int, b : int, c : int, increment : int) =
            let subject = ObjectId(a, b, c)
            let result = subject.Increment
            Assert.Equal(increment, result)

        [<Theory>]
        [<InlineData(0x01020304, 0x05060708, 0x090a0b0c, 0x00050607)>]
        [<InlineData(0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc, 0x00f5f6f7)>]
        member this.``Machine should return expected result``(a : int, b : int, c : int, machine : int) =
            let subject = ObjectId(a, b, c)
            let result = subject.Machine
            Assert.Equal(machine, result)

        [<Fact>]
        member this.``NewId returns expected result``() =
            let previous = ObjectId.NewId()
            let result = ObjectId.NewId()
            Assert.True(result.Timestamp = previous.Timestamp || result.Timestamp = previous.Timestamp + 1)
            Assert.Equal(previous.Machine, result.Machine)
            Assert.Equal(previous.Pid, result.Pid)
            Assert.Equal((previous.Increment + 1) &&& 0xffffff, result.Increment)

        [<Theory>]
        [<InlineData("0102030405060708090a0b0c", 0x01020304, 0x05060708, 0x090a0b0c)>]
        [<InlineData("f1f2f3f4f5f6f7f8f9fafbfc", 0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc)>]
        member this.``Parse returns expected result``(value : string, a : int, b : int, c : int) =
            let result = ObjectId.Parse(value)
            Assert.Equal(a, result.A)
            Assert.Equal(b, result.B)
            Assert.Equal(c, result.C)

        [<Theory>]
        [<InlineData(0x01020304, 0x05060708, 0x090a0b0c, 0x0809s)>]
        [<InlineData(0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc, 0xf8f9s)>]
        member this.``Pid should return expected result``(a : int, b : int, c : int, pid : int16) =
            let subject = ObjectId(a, b, c)
            let result = subject.Pid
            Assert.Equal(pid, result)

        [<Theory>]
        [<InlineData(0x01020304, 0x05060708, 0x090a0b0c, 0x01020304)>]
        [<InlineData(0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc, 0xf1f2f3f4)>]
        member this.``Timestamp should return expected result``(a : int, b : int, c : int, timestamp : int) =
            let subject = ObjectId(a, b, c)
            let result = subject.Timestamp
            Assert.Equal(timestamp, result)

        [<Theory>]
        [<InlineData(0x01020304, 0x05060708, 0x090a0b0c, "0102030405060708090a0b0c")>]
        [<InlineData(0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc, "f1f2f3f4f5f6f7f8f9fafbfc")>]
        member this.``ToBytes should return expected result``(a : int, b : int, c : int, bytes : string) =
            let subject = ObjectId(a, b, c)
            let bytes = Hex.ToByteArray(bytes);
            let result = subject.ToByteArray()
            Assert.Equal<byte>(bytes, result)

        [<Theory>]
        [<InlineData(0x01020304, 0x05060708, 0x090a0b0c, "0102030405060708090a0b0c")>]
        [<InlineData(0xf1f2f3f4, 0xf5f6f7f8, 0xf9fafbfc, "f1f2f3f4f5f6f7f8f9fafbfc")>]
        member this.``ToString should return expected result``(a : int, b : int, c : int, expectedResult : string) =
            let subject = ObjectId(a, b, c)
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)
  end
