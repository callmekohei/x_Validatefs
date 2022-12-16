namespace ValidateCore

module vDateOnly =

  open System

  let validateDateOrless (dt':DateOnly) (dt:DateOnly) =
    match dt <= dt' with
    | false -> Error $"{dt'}以前になってません"
    | _ -> Ok dt

  let validateDateEqual (dt':DateOnly) (dt:DateOnly) =
    match dt = dt' with
    | false -> Error $"{dt'}になってません"
    | _ -> Ok dt

  let validateDateNotEqual (dt':DateOnly) (dt:DateOnly) =
    match dt <> dt' with
    | false -> Error $"{dt'}以外になってません"
    | _ -> Ok dt

  let validateDateOrover (dt':DateOnly) (dt:DateOnly) =
    match dt >= dt' with
    | false -> Error $"{dt'}以降になってません"
    | _ -> Ok dt