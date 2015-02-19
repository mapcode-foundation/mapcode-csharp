/*
 * Copyright (C) 2014-2015 Stichting Mapcode Foundation (http://www.mapcode.com)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapcode.com
{
    internal class ParentTerritory
    {
        public static Dictionary<Territory.ParentTerritories, ParentTerritory> map = new Dictionary<Territory.ParentTerritories, ParentTerritory>()
        {
            { Territory.ParentTerritories.IND, new ParentTerritory(Territory.territories[Territory.Territories.IND]) },
            { Territory.ParentTerritories.AUS, new ParentTerritory(Territory.territories[Territory.Territories.AUS]) },
            { Territory.ParentTerritories.BRA, new ParentTerritory(Territory.territories[Territory.Territories.BRA]) },
            { Territory.ParentTerritories.USA, new ParentTerritory(Territory.territories[Territory.Territories.USA]) },
            { Territory.ParentTerritories.MEX, new ParentTerritory(Territory.territories[Territory.Territories.MEX]) },
            { Territory.ParentTerritories.CAN, new ParentTerritory(Territory.territories[Territory.Territories.CAN]) },
            { Territory.ParentTerritories.RUS, new ParentTerritory(Territory.territories[Territory.Territories.RUS]) },
            { Territory.ParentTerritories.CHN, new ParentTerritory(Territory.territories[Territory.Territories.CHN]) },
            { Territory.ParentTerritories.ATA, new ParentTerritory(Territory.territories[Territory.Territories.ATA]) }
        };

        public Territory getTerritory()
        {
            return territory;
        }

        private Territory territory;

        private ParentTerritory(Territory territory)
        {
            this.territory = territory;
        }
    }
}
