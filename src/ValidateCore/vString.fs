namespace ValidateCore

module vString =

  open System
  open System.Globalization

  let validateStringLengthOrover (n:int) (s:string) =
    match s.Length with
    | strLen when strLen < n  -> Error $"{n}文字以上になってません"
    | _ -> Ok s

  let validateStringLengthEqual (n:int) (s:string) =
    match s.Length with
    | strLen when strLen <> n  -> Error $"{n}文字になってません"
    | _ -> Ok s

  let validateStringLengthNotEqual (n:int) (s:string) =
    match s.Length with
    | strLen when strLen = n  -> Error $"{n}文字以外になってません"
    | _ -> Ok s

  let validateStringLengthOrless (n:int) (s:string) =
    match s.Length with
    | strLen when strLen > n  -> Error $"{n}文字以下になってません"
    | _ -> Ok s

  let validateStringIsEmpty (s:string) =
    match String.IsNullOrEmpty(s) with
    | false -> Error "空文字になってません"
    | _ -> Ok s

  let validateStringIsNotEmpty (s:string) =
    match String.IsNullOrEmpty(s) |> not with
    | false -> Error "文字がありません"
    | _ -> Ok s

  let validateStringContains (s':string) (s:string) =
    match s.Contains(s') with
    | false -> Error $"{s'}が含まれてません"
    | _ -> Ok s

  let validateStringNotContains (s':string) (s:string) =
    match s.Contains(s') |> not with
    | false -> Error $"{s'}が含まれています"
    | _ -> Ok s

  let validateStringListFind (lst:seq<string>) (s:string) =
    match lst |> Seq.exists(fun x -> s = x) with
    | false -> Error $"対象文字列群に含まれてません"
    | _ -> Ok s

  let validateStringNotListFind (lst:seq<string>) (s:string) =
    match lst |> Seq.exists(fun x -> s = x) |> not with
    | false -> Error $"対象文字列群に含まれています"
    | _ -> Ok s

  let validateStringParseInt (s:string) =
    match Int32.TryParse(s) |> fst with
    | false -> Error "数値として認識できません"
    | _ -> Ok s

  let validateStringParseDatetime (fmt:string) (s:string) =
    let (couldParse,_) =
      if String.IsNullOrEmpty(fmt)
      then DateTime.TryParse(s)
      else DateTime.TryParseExact(s,fmt, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None)
    match couldParse with
    | false -> Error "日付として認識できません"
    | _ -> Ok s