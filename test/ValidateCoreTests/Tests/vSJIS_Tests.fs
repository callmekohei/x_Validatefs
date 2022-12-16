namespace Tests

module vSJIS_Tests =

  open System.Text
  open Xunit
  open ValidateCore.vSJIS

  [<Fact>]
  let ``validateWidthFullAll ok`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Ok "あああ"
    let actual = validateWidthFullAll "あああ"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateWidthFullAll error`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Error "全角文字のみで成り立ってません"
    let actual = validateWidthFullAll "あああa"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateWidthHalfAll ok`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Ok "foo"
    let actual = validateWidthHalfAll "foo"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateWidthHalfAll error`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Error "半角文字のみで成り立ってません"
    let actual = validateWidthHalfAll "fooあ"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateWidthFullHalf ok`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Ok "あああfoo"
    let actual = validateWidthFullHalf "あああfoo"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateWidthFullHalf error1`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Error "全半角文字が混合されてません"
    let actual = validateWidthFullHalf "foo"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateWidthFullHalf error2`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Error "全半角文字が混合されてません"
    let actual = validateWidthFullHalf "あああ"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateByteCountOrover ok`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Ok "12345"
    let actual = validateByteCountOrover 5 "12345"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateByteCountOrover error`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Error "5文字(byte)以上になってません"
    let actual = validateByteCountOrover 5 "1234"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateByteCountEqual ok`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Ok "12345"
    let actual = validateByteCountEqual 5 "12345"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateByteCountEqual error`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Error "5文字(byte)になってません"
    let actual = validateByteCountEqual 5 "1234"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateByteCountNotEqual ok`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Ok "1234"
    let actual = validateByteCountNotEqual 5 "1234"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateByteCountNotEqual error`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Error "5文字(byte)以外になってません"
    let actual = validateByteCountNotEqual 5 "12345"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateByteCountOrless ok`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Ok "12345"
    let actual = validateByteCountOrless 5 "12345"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateByteCountOrless error`` () =
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    let expect = Error "5文字(byte)以下になってません"
    let actual = validateByteCountOrless 5 "123456"
    Assert.Equal(expect,actual)