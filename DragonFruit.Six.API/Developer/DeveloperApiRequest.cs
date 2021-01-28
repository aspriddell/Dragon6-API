﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;

namespace DragonFruit.Six.Api.Developer
{
    public abstract class DeveloperApiRequest : ApiRequest
    {
        protected const string BaseEndpoint = "https://dragon6.dragonfruit.network";

        protected override bool RequireAuth => true;
    }
}
