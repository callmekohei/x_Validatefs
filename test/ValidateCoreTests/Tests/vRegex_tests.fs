namespace Tests

module vRegex_Tests =

  open System.Text
  open Xunit
  open ValidateCore.vRegex

  [<Fact>]
  let ``validateRegex ok`` () =
    let expect = Ok "foooo"
    let actual = validateRegex "It's not foo" "f.*o" "foooo"
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateRegex error`` () =
    let expect = Error "It's not foo"
    let actual = validateRegex "It's not foo" "f.*o" "bar"
    Assert.Equal(expect,actual)