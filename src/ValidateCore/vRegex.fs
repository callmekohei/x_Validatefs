namespace ValidateCore

module vRegex =

  open System.Text.RegularExpressions

  let validateRegex (errMessage:string) (pattern:string) (s:string) =
    match Regex.IsMatch(s,pattern) with
    | false -> Error errMessage
    | _ -> Ok s

  let letter = {|

    // see also: DOBON.NET https://dobon.net/vb/dotnet/string/ishiragana.html#iskanji
    // see also: form用正規表現判定/備忘 https://qiita.com/fubarworld2/items/9da655df4d6d69750c06

    // 01.数字
    numeric        = @"0-9"
    numericWide    = @"０-９"
    numericAmb     = @"0-9０-９"
    numericPlus    = @"[-]?[0-9]+(\.[0-9]+)"       // 半角数値（マイナス、小数点）
    numericPlusAmb = @"[ー]?[０-９]+(\．[０-９]+)" // 全角数値（マイナス、小数点）

    // 02.文字
    alphabetLC    = @"a-z"
    alphabetUC    = @"A-Z"
    alphabet      = @"a-zA-Z"
    alphabetWide  = @"ａ-ｚＡ-Ｚ"
    alphabetAmb   = @"a-zA-Zａ-ｚＡ-Ｚ"

    hirakanaCore = @"\p{IsHiragana}"

    hirakana =
        @"\p{IsHiragana}"
      + @"\u30A0" // ダブルハイフン
      + @"\u002D\u30FC\u2010\u2011\u2013\u2014\u2015\u2212\uFF70" // ハイフン、長音記号

    katakanaCore = @"\p{IsKatakana}"

    katakana =
        @"\p{IsKatakana}"
      + @"\u31F0-\u31FF\u3099-\u309C\uFF65-\uFF9F" // 濁点カタカナ
      + @"\u002D\u30FC\u2010\u2011\u2013\u2014\u2015\u2212\uFF70" // ハイフン、長音記号

    kanji =
        @"[\p{IsCJKUnifiedIdeographs}"
      + @"\p{IsCJKCompatibilityIdeographs}"
      + @"\p{IsCJKUnifiedIdeographsExtensionA}]|"
      + @"[\uD840-\uD869][\uDC00-\uDFFF]|\uD869[\uDC00-\uDEDF]"

    hyphen = @"\u002D\u30FC\u2010\u2011\u2013\u2014\u2015\u2212\uFF70"

  |}

  let postalCode = {|

    zipCode357 = @"[0-9]{3}[-][0-9]{4}$|^[0-9]{3}[-][0-9]{2}$|^[0-9]{3}" // ハイフンあり3桁・5桁・7桁
    zipCode32  = @"[0-9]{3}[-][0-9]{2}"  // ハイフンあり5桁
    zipCode34  = @"[0-9]{3}[-][0-9]{4}"  // ハイフンあり7桁
    zipCode3   = @"[0-9]{3}"             // ハイフンなし3桁
    zipCode5   = @"[0-9]{5}"             // ハイフンなし5桁
    zipCode7   = @"[0-9]{7}"             // ハイフンなし7桁
    zipCode    = @"[0-9]{3}[-][0-9]{4}$|^[0-9]{3}[-][0-9]{2}$|^[0-9]{3}$|^[0-9]{5}$|^[0-9]{7}" // ハイフンあり・なし両方

  |}

  let postalCodeAmbiguousWide = {|

    zipCode357 = @"\d{3}[-]\d{4}$|^\d{3}[-]\d{2}$|^\d{3}" // ハイフンあり3桁・5桁・7桁
    zipCode32  = @"\d{3}[-]\d{2}"  // ハイフンあり5桁
    zipCode34  = @"\d{3}[-]\d{4}"  // ハイフンあり7桁
    zipCode3   = @"\d{3}"          // ハイフンなし3桁
    zipCode5   = @"\d{5}"          // ハイフンなし5桁
    zipCode7   = @"\d{7}"          // ハイフンなし7桁
    zipCode    = @"\d{3}[-]\d{4}$|^\d{3}[-]\d{2}$|^\d{3}$|^\d{5}$|^\d{7}" // ハイフンあり・なし両方

  |}

  let phone = {|

    line     = @"0[0-9]{9}"        // 0から始まる市外局番込の10桁の番号
    freedial = @"0120[0-9]{6}"     // フリーダイアル
    mobile   = @"0[5789]0[0-9]{8}" // 携帯電話とPHSは「070」、「080」又は「090」から始まる11桁の番号

  |}

  let email = {|

    easyCheck =  @"^[^@\s]+@[^@\s]+\.[^@\s]+$"

  |}