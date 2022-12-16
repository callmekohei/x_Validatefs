namespace ValidateCore

module vSJIS =

  open System.Text

  let validateWidthFullAll (s:string) =
    match Encoding.GetEncoding("Shift_JIS").GetByteCount(s) = s.Length * 2 with
    | false -> Error "全角文字のみで成り立ってません"
    | _ -> Ok s

  let validateWidthHalfAll (s:string) =
    match Encoding.GetEncoding("Shift_JIS").GetByteCount(s) = s.Length with
    | false -> Error "半角文字のみで成り立ってません"
    | _ -> Ok s

  let validateWidthFullHalf (s:string) =
    let byteCount = Encoding.GetEncoding("Shift_JIS").GetByteCount(s)
    match (byteCount <> s.Length) && (byteCount <> s.Length * 2) with
    | false -> Error "全半角文字が混合されてません"
    | _ -> Ok s

  let validateByteCountOrover (n:int) (s:string) =
    match Encoding.GetEncoding("Shift_JIS").GetByteCount(s) with
    | byteCount when byteCount < n -> Error $"{n}文字(byte)以上になってません"
    | _ -> Ok s

  let validateByteCountEqual (n:int) (s:string) =
    match Encoding.GetEncoding("Shift_JIS").GetByteCount(s) with
    | byteCount when byteCount <> n -> Error $"{n}文字(byte)になってません"
    | _ -> Ok s

  let validateByteCountNotEqual (n:int) (s:string) =
    match Encoding.GetEncoding("Shift_JIS").GetByteCount(s) with
    | byteCount when byteCount = n -> Error $"{n}文字(byte)以外になってません"
    | _ -> Ok s

  let validateByteCountOrless (n:int) (s:string) =
    match Encoding.GetEncoding("Shift_JIS").GetByteCount(s) with
    | byteCount when byteCount > n -> Error $"{n}文字(byte)以下になってません"
    | _ -> Ok s