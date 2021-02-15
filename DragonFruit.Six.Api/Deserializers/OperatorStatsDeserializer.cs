﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class OperatorStatsDeserializer
    {
        public static ILookup<string, OperatorStats> DeserializeOperatorStats(this JObject jObject, IEnumerable<OperatorStats> data)
        {
            var results = jObject[Misc.Results]?.ToObject<Dictionary<string, JObject>>();
            var enumeratedResults = results?.SelectMany(x => DeserializeInternal(x, data)) ?? Enumerable.Empty<OperatorStats>();

            return enumeratedResults.ToLookup(x => x.ProfileId);
        }

        private static IEnumerable<OperatorStats> DeserializeInternal(KeyValuePair<string, JObject> data, IEnumerable<OperatorStats> operators)
        {
            foreach (var op in operators.Select(x => x.Clone()))
            {
                op.ProfileId = data.Key;

                op.Kills = data.Value.GetUInt(Operator.Kills.ToIndexedStatsKey(op.Index));
                op.Deaths = data.Value.GetUInt(Operator.Deaths.ToIndexedStatsKey(op.Index));

                op.Wins = data.Value.GetUInt(Operator.Wins.ToIndexedStatsKey(op.Index));
                op.Losses = data.Value.GetUInt(Operator.Losses.ToIndexedStatsKey(op.Index));

                op.RoundsPlayed = data.Value.GetUInt(Operator.Rounds.ToIndexedStatsKey(op.Index));
                op.Duration = data.Value.GetUInt(Operator.Time.ToIndexedStatsKey(op.Index));

                op.Headshots = data.Value.GetUInt(Operator.Headshots.ToIndexedStatsKey(op.Index));
                op.Downs = data.Value.GetUInt(Operator.Downs.ToIndexedStatsKey(op.Index));

                op.Experience = data.Value.GetUInt(Operator.Experience.ToIndexedStatsKey(op.Index));
                op.ActionCount = (uint?)data.Value[op.OperatorActionResultId];

                yield return op;
            }
        }
    }
}
