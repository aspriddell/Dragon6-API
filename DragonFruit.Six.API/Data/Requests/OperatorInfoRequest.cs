﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;

namespace DragonFruit.Six.API.Data.Requests
{
    public class OperatorInfoRequest : ApiRequest
    {
        public override string Path => "https://raw.githubusercontent.com/dragonfruitnetwork/Dragon6-Assets/master/public/data/operators.json";
    }
}
