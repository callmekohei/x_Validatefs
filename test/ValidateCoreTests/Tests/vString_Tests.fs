namespace Tests

module vString_Tests =

  open System.Text
  open Xunit
  open ValidateCore.vString

  [<Fact>]
  let ``validateStringLengthOrover ok`` () =
    let expect = Ok "あがＡ阿５ｱｶﾞa5"
    let actual = validateStringLengthOrover 10 "あがＡ阿５ｱｶﾞa5"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringLengthOrover errror`` () =
    let expect = Error "10文字以上になってません"
    let actual = validateStringLengthOrover 10 "foo"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringLengthEqual ok`` () =
    let expect = Ok "12345"
    let actual = validateStringLengthEqual 5 "12345"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringLengthEqual error1`` () =
    let expect = Error "5文字になってません"
    let actual = validateStringLengthEqual 5 "1234"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringLengthEqual error2`` () =
    let expect = Error "5文字になってません"
    let actual = validateStringLengthEqual 5 "123456"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringLengthNotEqual ok1`` () =
    let expect = Ok "1234"
    let actual = validateStringLengthNotEqual 5 "1234"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringLengthNotEqual ok2`` () =
    let expect = Ok "123456"
    let actual = validateStringLengthNotEqual 5 "123456"
    Assert.Equal(expect,actual)


  [<Fact>]
  let ``validateStringLengthNotEqual error`` () =
    let expect = Error "5文字以外になってません"
    let actual = validateStringLengthNotEqual 5 "12345"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringLengthOrless ok`` () =
    let expect = Ok "12345"
    let actual = validateStringLengthOrless 5 "12345"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringLengthOrless errror`` () =
    let expect = Error "5文字以下になってません"
    let actual = validateStringLengthOrless 5 "123456"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringIsEmpty ok`` () =
    let expect = Ok ""
    let actual = validateStringIsEmpty ""
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringIsEmpty error`` () =
    let expect = Error "空文字になってません"
    let actual = validateStringIsEmpty "foo"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringIsNotEmpty ok`` () =
    let expect = Ok "foo"
    let actual = validateStringIsNotEmpty "foo"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringIsNotEmpty error`` () =
    let expect = Error "文字がありません"
    let actual = validateStringIsNotEmpty ""
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringContains ok`` () =
    let expect = Ok "foobarbaz"
    let actual = validateStringContains "bar" "foobarbaz"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringContains error`` () =
    let expect = Error "hogeが含まれてません"
    let actual = validateStringContains "hoge" "foobarbaz"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringNotContains ok`` () =
    let expect = Ok "foobarbaz"
    let actual = validateStringNotContains "hoge" "foobarbaz"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringNotContains error`` () =
    let expect = Error "barが含まれています"
    let actual = validateStringNotContains "bar" "foobarbaz"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringListFind ok`` () =
    let expect = Ok "baz"
    let actual = validateStringListFind ["foo";"bar";"baz"] "baz"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringListFind error`` () =
    let expect = Error "対象文字列群に含まれてません"
    let actual = validateStringListFind ["foo";"bar";"baz"] "hoge"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringNotListFind ok`` () =
    let expect = Ok "hoge"
    let actual = validateStringNotListFind ["foo";"bar";"baz"] "hoge"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringNotListFind error`` () =
    let expect = Error "対象文字列群に含まれています"
    let actual = validateStringNotListFind ["foo";"bar";"baz"] "bar"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringParseInt ok`` () =
    let expect = Ok "123"
    let actual = validateStringParseInt "123"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringParseInt error`` () =
    let expect = Error "数値として認識できません"
    let actual = validateStringParseInt "foo"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringParseDatetime ok1`` () =
    let expect = Ok "2022-12-16 18:14:22"
    let actual = validateStringParseDatetime "" "2022-12-16 18:14:22"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringParseDatetime ok2`` () =
    let expect = Ok "202212"
    let actual = validateStringParseDatetime "yyyyMM" "202212"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateStringParseDatetime error`` () =
    let expect = Error "日付として認識できません"
    let actual = validateStringParseDatetime "" "foo"
    Assert.Equal(expect,actual)