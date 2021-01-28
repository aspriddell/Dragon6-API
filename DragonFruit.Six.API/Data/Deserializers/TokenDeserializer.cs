﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Data.Containers;
using DragonFruit.Six.Api.Data.Strings;
using DragonFruit.Six.Api.Data.Tokens;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Data.Deserializers
{
    public static class TokenDeserializer
    {
        public static UbisoftToken DeserializeToken(this JObject jObject)
        {
            var token = jObject.ToObject<UbisoftToken>();

            if (token == null)
                return null;

            token.Account = new AccountInfo
            {
                Platform = PlatformParser.PlatformEnumFor(jObject.GetString(Accounts.PlatformIdentifier, "uplay")),
                PlayerName = jObject.GetString(Accounts.Name),
                Identifiers = new UserIdentifiers
                {
                    Platform = jObject.GetString(Accounts.ProfileIdentifier)
                }
            };

            return token;
        }
    }
}
