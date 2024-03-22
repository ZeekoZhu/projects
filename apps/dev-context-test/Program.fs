open FsUnit.TopLevelOperators
open NUnit.Framework

module Program =

  [<SetUpFixture>]
  type InitMsgUtils() =
    inherit FSharpCustomMessageFormatter()

  [<EntryPoint>]
  let main _ = 0
