namespace Tests

module vDateOnly_Tests =

  open System
  open Xunit
  open ValidateCore.vDateOnly

  [<Fact>]
  let ``validateDateOrless ok`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/14")
    let expect = Ok dt
    let actual = validateDateOrless dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateOrless error`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/30")
    let expect = Error "2022/12/25以前になってません"
    let actual = validateDateOrless dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateEqual ok`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/25")
    let expect = Ok dt
    let actual = validateDateEqual dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateEqual error1`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/10")
    let expect = Error $"{dt'}になってません"
    let actual = validateDateEqual dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateEqual error2`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/30")
    let expect = Error $"{dt'}になってません"
    let actual = validateDateEqual dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateNotEqual ok1`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/10")
    let expect = Ok dt
    let actual = validateDateNotEqual dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateNotEqual ok2`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/30")
    let expect = Ok dt
    let actual = validateDateNotEqual dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateNotEqual error`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/25")
    let expect = Error $"{dt'}以外になってません"
    let actual = validateDateNotEqual dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateOrover ok`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/30")
    let expect = Ok dt
    let actual = validateDateOrover dt' dt
    Assert.Equal(expect,actual)

  [<Fact>]
  let ``validateDateOrover error`` () =
    let dt' = DateOnly.Parse("2022/12/25")
    let dt  = DateOnly.Parse("2022/12/10")
    let expect = Error "2022/12/25以降になってません"
    let actual = validateDateOrover dt' dt
    Assert.Equal(expect,actual)