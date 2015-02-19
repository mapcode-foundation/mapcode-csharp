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
    internal class Territory
    {
        public enum Territories
        {
            USA,
            IND,
            CAN,
            AUS,
            MEX,
            BRA,
            RUS,
            CHN,
            ATA,

            VAT,
            MCO,
            GIB,
            TKL,
            CCK,
            BLM,
            NRU,
            TUV,
            MAC,
            SXM,
            MAF,
            NFK,

            PCN,
            BVT,
            BMU,
            IOT,
            SMR,
            GGY,
            AIA,
            MSR,
            JEY,
            CXR,
            WLF,
            VGB,
            LIE,
            ABW,
            MHL,
            ASM,
            COK,
            SPM,
            NIU,
            KNA,
            CYM,
            BES,
            MDV,
            SHN,

            MLT,
            GRD,
            VIR,
            MYT,
            SJM,
            VCT,
            HMD,

            BRB,
            ATG,
            CUW,
            SYC,
            PLW,
            MNP,
            AND,
            GUM,
            IMN,
            LCA,
            FSM,
            SGP,
            TON,
            DMA,
            BHR,
            KIR,
            TCA,
            STP,
            HKG,
            MTQ,
            FRO,
            GLP,
            COM,
            MUS,
            REU,
            LUX,
            WSM,
            SGS,
            PYF,
            CPV,
            TTO,
            BRN,
            ATF,
            PRI,
            CYP,
            LBN,
            JAM,
            GMB,
            QAT,
            FLK,
            VUT,
            MNE,
            BHS,
            TLS,
            SWZ,
            KWT,
            FJI,
            NCL,
            SVN,
            ISR,
            PSE,
            SLV,
            BLZ,
            DJI,
            MKD,
            RWA,
            HTI,
            BDI,
            GNQ,
            ALB,
            SLB,
            ARM,
            LSO,
            BEL,
            MDA,
            GNB,
            TWN,
            BTN,
            CHE,
            NLD,
            DNK,
            EST,
            DOM,
            SVK,
            CRI,
            BIH,
            HRV,
            TGO,
            LVA,
            LTU,
            LKA,
            GEO,
            IRL,
            SLE,
            PAN,
            CZE,
            GUF,
            ARE,
            AUT,
            AZE,
            SRB,
            JOR,
            PRT,
            HUN,
            KOR,
            ISL,
            GTM,
            CUB,
            BGR,
            LBR,
            HND,
            BEN,
            ERI,
            MWI,
            PRK,
            NIC,
            GRC,
            TJK,
            BGD,
            NPL,
            TUN,
            SUR,
            URY,
            KHM,
            SYR,
            SEN,
            KGZ,
            BLR,
            GUY,
            LAO,
            ROU,
            GHA,
            UGA,
            GBR,

            GIN,
            ECU,
            ESH,
            GAB,
            NZL,
            BFA,
            PHL,
            ITA,
            OMN,
            POL,
            CIV,
            NOR,
            MYS,
            VNM,
            FIN,
            COG,
            DEU,
            JPN,
            ZWE,
            PRY,
            IRQ,
            MAR,
            UZB,
            SWE,
            PNG,
            CMR,
            TKM,
            ESP,
            THA,
            YEM,
            FRA,
            ALA,
            KEN,
            BWA,
            MDG,
            UKR,
            SSD,
            CAF,
            SOM,
            AFG,
            MMR,
            ZMB,
            CHL,
            TUR,
            PAK,
            MOZ,
            NAM,
            VEN,
            NGA,
            TZA,
            EGY,
            MRT,
            BOL,
            ETH,
            COL,
            ZAF,
            MLI,
            AGO,
            NER,
            TCD,
            PER,
            MNG,
            IRN,
            LBY,
            SDN,
            IDN,
            MX_DIF,
            MX_TLA,
            MX_MOR,
            MX_AGU,
            MX_CL,
            MX_QUE,
            MX_HID,
            MX_MX,
            MX_TAB,
            MX_NAY,
            MX_GUA,
            MX_PUE,
            MX_YUC,
            MX_ROO,
            MX_SIN,
            MX_CAM,
            MX_MIC,
            MX_SLP,
            MX_GRO,
            MX_NLE,
            MX_BCN,
            MX_VER,
            MX_CHP,
            MX_BCS,
            MX_ZAC,
            MX_JAL,
            MX_TAM,
            MX_OAX,
            MX_DUR,
            MX_COA,
            MX_SON,
            MX_CHH,
            GRL,
            SAU,
            COD,
            DZA,
            KAZ,
            ARG,
            IN_DD,
            IN_DN,
            IN_CH,
            IN_AN,
            IN_LD,
            IN_DL,
            IN_ML,
            IN_NL,
            IN_MN,
            IN_TR,
            IN_MZ,
            IN_SK,
            IN_PB,
            IN_HR,
            IN_AR,
            IN_AS,
            IN_BR,
            IN_UT,
            IN_GA,
            IN_KL,
            IN_TN,
            IN_HP,
            IN_JK,
            IN_CT,
            IN_JH,
            IN_KA,
            IN_RJ,
            IN_OR,
            IN_GJ,
            IN_WB,
            IN_MP,
            IN_TG,
            IN_AP,
            IN_MH,
            IN_UP,
            IN_PY,
            AU_NSW,
            AU_ACT,
            AU_JBT,
            AU_NT,
            AU_SA,
            AU_TAS,
            AU_VIC,
            AU_WA,
            AU_QLD,
            BR_DF,
            BR_SE,
            BR_AL,
            BR_RJ,
            BR_ES,
            BR_RN,
            BR_PB,
            BR_SC,
            BR_PE,
            BR_AP,
            BR_CE,
            BR_AC,
            BR_PR,
            BR_RR,
            BR_RO,
            BR_SP,
            BR_PI,
            BR_TO,
            BR_RS,
            BR_MA,
            BR_GO,
            BR_MS,
            BR_BA,
            BR_MG,
            BR_MT,
            BR_PA,
            BR_AM,
            US_DC,
            US_RI,
            US_DE,
            US_CT,
            US_NJ,
            US_NH,
            US_VT,
            US_MA,
            US_HI,
            US_MD,
            US_WV,
            US_SC,
            US_ME,
            US_IN,
            US_KY,
            US_TN,
            US_VA,
            US_OH,
            US_PA,
            US_MS,
            US_LA,
            US_AL,
            US_AR,
            US_NC,
            US_NY,
            US_IA,
            US_IL,
            US_GA,
            US_WI,
            US_FL,
            US_MO,
            US_OK,
            US_ND,
            US_WA,
            US_SD,
            US_NE,
            US_KS,
            US_ID,
            US_UT,
            US_MN,
            US_MI,
            US_WY,
            US_OR,
            US_CO,
            US_NV,
            US_AZ,
            US_NM,
            US_MT,
            US_CA,
            US_TX,
            US_AK,
            CA_BC,
            CA_AB,
            CA_ON,
            CA_QC,
            CA_SK,
            CA_MB,
            CA_NL,
            CA_NB,
            CA_NS,
            CA_PE,
            CA_YT,
            CA_NT,
            CA_NU,
            RU_MOW,
            RU_SPE,
            RU_KGD,
            RU_IN,
            RU_AD,
            RU_SE,
            RU_KB,
            RU_KC,
            RU_CE,
            RU_CU,
            RU_IVA,
            RU_LIP,
            RU_ORL,
            RU_TUL,
            RU_BE,
            RU_VLA,
            RU_KRS,
            RU_KLU,
            RU_TT,
            RU_BRY,
            RU_YAR,
            RU_RYA,
            RU_AST,
            RU_MOS,
            RU_SMO,
            RU_DA,
            RU_VOR,
            RU_NGR,
            RU_PSK,
            RU_KOS,
            RU_STA,
            RU_KDA,
            RU_KL,
            RU_TVE,
            RU_LEN,
            RU_ROS,
            RU_VGG,
            RU_VLG,
            RU_MUR,
            RU_KR,
            RU_NEN,
            RU_KO,
            RU_ARK,
            RU_MO,
            RU_NIZ,
            RU_PNZ,
            RU_KI,
            RU_ME,
            RU_ORE,
            RU_ULY,
            RU_PM,
            RU_BA,
            RU_UD,
            RU_TA,
            RU_SAM,
            RU_SAR,
            RU_YAN,
            RU_KM,
            RU_SVE,
            RU_TYU,
            RU_KGN,
            RU_CH,
            RU_BU,
            RU_ZAB,
            RU_IRK,
            RU_NVS,
            RU_TOM,
            RU_OMS,
            RU_KK,
            RU_KEM,
            RU_AL,
            RU_ALT,
            RU_TY,
            RU_KYA,
            RU_MAG,
            RU_CHU,
            RU_KAM,
            RU_SAK,
            RU_PO,
            RU_YEV,
            RU_KHA,
            RU_AMU,
            RU_SA,
            CN_SH,
            CN_TJ,
            CN_BJ,
            CN_HI,
            CN_NX,
            CN_CQ,
            CN_ZJ,
            CN_JS,
            CN_FJ,
            CN_AH,
            CN_LN,
            CN_SD,
            CN_SX,
            CN_JX,
            CN_HA,
            CN_GZ,
            CN_GD,
            CN_HB,
            CN_JL,
            CN_HE,
            CN_SN,
            CN_NM,
            CN_HL,
            CN_HN,
            CN_GX,
            CN_SC,
            CN_YN,
            CN_XZ,
            CN_GS,
            CN_QH,
            CN_XJ,
            UMI,
            CPT,
            AT0,
            AT1,
            AT2,
            AT3,
            AT4,
            AT5,
            AT6,
            AT7,
            AT8,
            AAA
        }

        // ROBOCOP: Since Territories is a separate enum, there is no need for ParentTerritories?
        public enum ParentTerritories
        {
            IND,
            AUS,
            BRA,
            USA,
            MEX,
            CAN,
            RUS,
            CHN,
            ATA
        };

        /**
         * Enumeration that specifies the format for mapcodes.
         */
        public enum NameFormat
        {
            INTERNATIONAL,          // Same as name() with underscores replaces with dashes.
            MINIMAL_UNAMBIGUOUS,    // Minimal code, which is still unambiguous.
            MINIMAL                 // Minimal code, may be ambiguous, eg. RJ instead of IN-RJ.
        }

        private int territoryCode;
        private string fullName;
        private ParentTerritories? parentTerritory;
        private Territory ParentTerritory
        {
             get
             {
                 return (parentTerritory == null) ? null : mapcode.com.ParentTerritory.map[parentTerritory.Value].getTerritory();
             }
        }
        private string[] aliases;
        private string[] fullNameAliases;

        private static List<Territory> codeList = new List<Territory>();
        private static Dictionary<string, List<Territory>> nameMap = new Dictionary<string, List<Territory>>();
        private static List<Territory> parentList = new List<Territory>();

        /**
         * Local constructors to create a territory code.
         */
        private Territory(int territoryCode, string fullName) : this(territoryCode, fullName, null, null, null)
        {
        }

        private Territory(int territoryCode, string fullName, ParentTerritories? parentTerritory) : this(territoryCode, fullName, parentTerritory, null, null)
        {
        }

        private Territory(int territoryCode, string fullName, ParentTerritories? parentTerritory, string[] aliases) : this(territoryCode, fullName, parentTerritory, aliases, null)
        {
        }

        private Territory(int territoryCode, string fullName, ParentTerritories? parentTerritory, string[] aliases, string[] fullNameAliases)
        {
            this.territoryCode = territoryCode;
            this.fullName = fullName;
            this.parentTerritory = parentTerritory;
            this.aliases = (aliases == null) ? new string[]{} : aliases;
            this.fullNameAliases = (fullNameAliases == null) ? new string[]{} : fullNameAliases;
        }

        public static Dictionary<Territories, Territory> territories = new Dictionary<Territories,Territory>()
        {
            { Territories.USA, new Territory(410, "USA", null, new string[]{"US"}, new string[]{"United States of America", "America"}) },
            { Territories.IND, new Territory(407, "India", null, new string[]{"IN"}) },
            { Territories.CAN, new Territory(495, "Canada", null, new string[]{"CA"}) },
            { Territories.AUS, new Territory(408, "Australia", null, new string[]{"AU"}) },
            { Territories.MEX, new Territory(411, "Mexico", null, new string[]{"MX"}) },
            { Territories.BRA, new Territory(409, "Brazil", null, new string[]{"BR"}) },
            { Territories.RUS, new Territory(496, "Russia", null, new string[]{"RU"}) },
            { Territories.CHN, new Territory(528, "China", null, new string[]{"CN"}) },
            { Territories.ATA, new Territory(540, "Antarctica") },
            { Territories.VAT, new Territory(0, "Vatican City", null, null, new string[]{"Holy See)"}) },
            { Territories.MCO, new Territory(1, "Monaco") },
            { Territories.GIB, new Territory(2, "Gibraltar") },
            { Territories.TKL, new Territory(3, "Tokelau") },
            { Territories.CCK, new Territory(4, "Cocos Islands", null, new string[]{"AU-CC", "AUS-CC"}, new string[]{"Keeling Islands"}) },
            { Territories.BLM, new Territory(5, "Saint-Barthelemy") },
            { Territories.NRU, new Territory(6, "Nauru") },
            { Territories.TUV, new Territory(7, "Tuvalu") },
            { Territories.MAC, new Territory(8, "Macau", null, new string[]{"CN-92", "CHN-92", "CN-MC", "CHN-MC"}) },
            { Territories.SXM, new Territory(9, "Sint Maarten") },
            { Territories.MAF, new Territory(10, "Saint-Martin") },
            { Territories.NFK, new Territory(11, "Norfolk and Philip Island", null, new string[]{"AU-NI", "AUS-NI", "AU-NF", "AUS-NF"},
                    new string[]{"Philip Island"}) },
            { Territories.PCN, new Territory(12, "Pitcairn Islands") },
            { Territories.BVT, new Territory(13, "Bouvet Island") },
            { Territories.BMU, new Territory(14, "Bermuda") },
            { Territories.IOT, new Territory(15, "British Indian Ocean Territory", null, new string[]{"DGA"}) },
            { Territories.SMR, new Territory(16, "San Marino") },
            { Territories.GGY, new Territory(17, "Guernsey") },
            { Territories.AIA, new Territory(18, "Anguilla") },
            { Territories.MSR, new Territory(19, "Montserrat") },
            { Territories.JEY, new Territory(20, "Jersey") },
            { Territories.CXR, new Territory(21, "Christmas Island", null, new string[]{"AU-CX", "AUS-CX"}) },
            { Territories.WLF, new Territory(22, "Wallis and Futuna", null, null, new string[]{"Futuna"}) },
            { Territories.VGB, new Territory(23, "British Virgin Islands", null, null, new string[]{"Virgin Islands, British"}) },
            { Territories.LIE, new Territory(24, "Liechtenstein") },
            { Territories.ABW, new Territory(25, "Aruba") },
            { Territories.MHL, new Territory(26, "Marshall Islands", null, new string[]{"WAK"}) },
            { Territories.ASM, new Territory(27, "American Samoa", null, new string[]{"US-AS", "USA-AS"}, new string[]{"Samoa, American"}) },
            { Territories.COK, new Territory(28, "Cook islands") },
            { Territories.SPM, new Territory(29, "Saint Pierre and Miquelon", null, null, new string[]{"Miquelon"}) },
            { Territories.NIU, new Territory(30, "Niue") },
            { Territories.KNA, new Territory(31, "Saint Kitts and Nevis", null, null, new string[]{"Nevis"}) },
            { Territories.CYM, new Territory(32, "Cayman islands") },
            { Territories.BES, new Territory(33, "Bonaire, St Eustasuis and Saba", null, null, new string[]{"Saba", "St Eustasius"}) },
            { Territories.MDV, new Territory(34, "Maldives") },
            { Territories.SHN, new Territory(35, "Saint Helena, Ascension and Tristan da Cunha", null, new string[]{"TAA", "ASC"},
                new string[]{"Ascension", "Tristan da Cunha"}) },
            { Territories.MLT, new Territory(36, "Malta") },
            { Territories.GRD, new Territory(37, "Grenada") },
            { Territories.VIR, new Territory(38, "US Virgin Islands", null, new string[]{"US-VI", "USA-VI"}, new string[]{"Virgin Islands, US"}) },
            { Territories.MYT, new Territory(39, "Mayotte") },
            { Territories.SJM, new Territory(40, "Svalbard and Jan Mayen", null, null, new string[]{"Jan Mayen"}) },
            { Territories.VCT, new Territory(41, "Saint Vincent and the Grenadines", null, null, new string[]{"Grenadines"}) },
            { Territories.HMD, new Territory(42, "Heard Island and McDonald Islands", null, new string[]{"AU-HM", "AUS-HM"},
                new string[]{"McDonald Islands"}) },
            { Territories.BRB, new Territory(43, "Barbados") },
            { Territories.ATG, new Territory(44, "Antigua and Barbuda", null, null, new string[]{"Barbuda"}) },
            { Territories.CUW, new Territory(45, "Curacao") },
            { Territories.SYC, new Territory(46, "Seychelles") },
            { Territories.PLW, new Territory(47, "Palau") },
            { Territories.MNP, new Territory(48, "Northern Mariana Islands", null, new string[]{"US-MP", "USA-MP"}) },
            { Territories.AND, new Territory(49, "Andorra") },
            { Territories.GUM, new Territory(50, "Guam", null, new string[]{"US-GU", "USA-GU"}) },
            { Territories.IMN, new Territory(51, "Isle of Man") },
            { Territories.LCA, new Territory(52, "Saint Lucia") },
            { Territories.FSM, new Territory(53, "Micronesia", null, null, new string[]{"Federated States of Micronesia"}) },
            { Territories.SGP, new Territory(54, "Singapore") },
            { Territories.TON, new Territory(55, "Tonga") },
            { Territories.DMA, new Territory(56, "Dominica") },
            { Territories.BHR, new Territory(57, "Bahrain") },
            { Territories.KIR, new Territory(58, "Kiribati") },
            { Territories.TCA, new Territory(59, "Turks and Caicos Islands", null, null, new string[]{"Caicos Islands"}) },
            { Territories.STP, new Territory(60, "Sao Tome and Principe", null, null, new string[]{"Principe"}) },
            { Territories.HKG, new Territory(61, "Hong Kong", null, new string[]{"CN-91", "CHN-91", "CN-HK", "CHN-HK"}) },
            { Territories.MTQ, new Territory(62, "Martinique") },
            { Territories.FRO, new Territory(63, "Faroe Islands") },
            { Territories.GLP, new Territory(64, "Guadeloupe") },
            { Territories.COM, new Territory(65, "Comoros") },
            { Territories.MUS, new Territory(66, "Mauritius") },
            { Territories.REU, new Territory(67, "Reunion") },
            { Territories.LUX, new Territory(68, "Luxembourg") },
            { Territories.WSM, new Territory(69, "Samoa") },
            { Territories.SGS, new Territory(70, "South Georgia and the South Sandwich Islands", null, null, new string[]{"South Sandwich Islands"}) },
            { Territories.PYF, new Territory(71, "French Polynesia") },
            { Territories.CPV, new Territory(72, "Cape Verde") },
            { Territories.TTO, new Territory(73, "Trinidad and Tobago", null, null, new string[]{"Tobago"}) },
            { Territories.BRN, new Territory(74, "Brunei") },
            { Territories.ATF, new Territory(75, "French Southern and Antarctic Lands") },
            { Territories.PRI, new Territory(76, "Puerto Rico", null, new string[]{"US-PR", "USA-PR"}) },
            { Territories.CYP, new Territory(77, "Cyprus") },
            { Territories.LBN, new Territory(78, "Lebanon") },
            { Territories.JAM, new Territory(79, "Jamaica") },
            { Territories.GMB, new Territory(80, "Gambia") },
            { Territories.QAT, new Territory(81, "Qatar") },
            { Territories.FLK, new Territory(82, "Falkland Islands") },
            { Territories.VUT, new Territory(83, "Vanuatu") },
            { Territories.MNE, new Territory(84, "Montenegro") },
            { Territories.BHS, new Territory(85, "Bahamas") },
            { Territories.TLS, new Territory(86, "East Timor") },
            { Territories.SWZ, new Territory(87, "Swaziland") },
            { Territories.KWT, new Territory(88, "Kuwait") },
            { Territories.FJI, new Territory(89, "Fiji Islands") },
            { Territories.NCL, new Territory(90, "New Caledonia") },
            { Territories.SVN, new Territory(91, "Slovenia") },
            { Territories.ISR, new Territory(92, "Israel") },
            { Territories.PSE, new Territory(93, "Palestinian territory") },
            { Territories.SLV, new Territory(94, "El Salvador") },
            { Territories.BLZ, new Territory(95, "Belize") },
            { Territories.DJI, new Territory(96, "Djibouti") },
            { Territories.MKD, new Territory(97, "Macedonia") },
            { Territories.RWA, new Territory(98, "Rwanda") },
            { Territories.HTI, new Territory(99, "Haiti") },
            { Territories.BDI, new Territory(100, "Burundi") },
            { Territories.GNQ, new Territory(101, "Equatorial Guinea") },
            { Territories.ALB, new Territory(102, "Albania") },
            { Territories.SLB, new Territory(103, "Solomon Islands") },
            { Territories.ARM, new Territory(104, "Armenia") },
            { Territories.LSO, new Territory(105, "Lesotho") },
            { Territories.BEL, new Territory(106, "Belgium") },
            { Territories.MDA, new Territory(107, "Moldova") },
            { Territories.GNB, new Territory(108, "Guinea-Bissau") },
            { Territories.TWN, new Territory(109, "Taiwan", null, new string[]{"CN-71", "CHN-71", "CN-TW", "CHN-TW"}) },
            { Territories.BTN, new Territory(110, "Bhutan") },
            { Territories.CHE, new Territory(111, "Switzerland") },
            { Territories.NLD, new Territory(112, "Netherlands") },
            { Territories.DNK, new Territory(113, "Denmark") },
            { Territories.EST, new Territory(114, "Estonia") },
            { Territories.DOM, new Territory(115, "Dominican Republic") },
            { Territories.SVK, new Territory(116, "Slovakia") },
            { Territories.CRI, new Territory(117, "Costa Rica") },
            { Territories.BIH, new Territory(118, "Bosnia and Herzegovina") },
            { Territories.HRV, new Territory(119, "Croatia") },
            { Territories.TGO, new Territory(120, "Togo") },
            { Territories.LVA, new Territory(121, "Latvia") },
            { Territories.LTU, new Territory(122, "Lithuania") },
            { Territories.LKA, new Territory(123, "Sri Lanka") },
            { Territories.GEO, new Territory(124, "Georgia") },
            { Territories.IRL, new Territory(125, "Ireland") },
            { Territories.SLE, new Territory(126, "Sierra Leone") },
            { Territories.PAN, new Territory(127, "Panama") },
            { Territories.CZE, new Territory(128, "Czech Republic") },
            { Territories.GUF, new Territory(129, "French Guiana") },
            { Territories.ARE, new Territory(130, "United Arab Emirates") },
            { Territories.AUT, new Territory(131, "Austria") },
            { Territories.AZE, new Territory(132, "Azerbaijan") },
            { Territories.SRB, new Territory(133, "Serbia") },
            { Territories.JOR, new Territory(134, "Jordan") },
            { Territories.PRT, new Territory(135, "Portugal") },
            { Territories.HUN, new Territory(136, "Hungary") },
            { Territories.KOR, new Territory(137, "South Korea") },
            { Territories.ISL, new Territory(138, "Iceland") },
            { Territories.GTM, new Territory(139, "Guatemala") },
            { Territories.CUB, new Territory(140, "Cuba") },
            { Territories.BGR, new Territory(141, "Bulgaria") },
            { Territories.LBR, new Territory(142, "Liberia") },
            { Territories.HND, new Territory(143, "Honduras") },
            { Territories.BEN, new Territory(144, "Benin") },
            { Territories.ERI, new Territory(145, "Eritrea") },
            { Territories.MWI, new Territory(146, "Malawi") },
            { Territories.PRK, new Territory(147, "North Korea") },
            { Territories.NIC, new Territory(148, "Nicaragua") },
            { Territories.GRC, new Territory(149, "Greece") },
            { Territories.TJK, new Territory(150, "Tajikistan") },
            { Territories.BGD, new Territory(151, "Bangladesh") },
            { Territories.NPL, new Territory(152, "Nepal") },
            { Territories.TUN, new Territory(153, "Tunisia") },
            { Territories.SUR, new Territory(154, "Suriname") },
            { Territories.URY, new Territory(155, "Uruguay") },
            { Territories.KHM, new Territory(156, "Cambodia") },
            { Territories.SYR, new Territory(157, "Syria") },
            { Territories.SEN, new Territory(158, "Senegal") },
            { Territories.KGZ, new Territory(159, "Kyrgyzstan") },
            { Territories.BLR, new Territory(160, "Belarus") },
            { Territories.GUY, new Territory(161, "Guyana") },
            { Territories.LAO, new Territory(162, "Laos") },
            { Territories.ROU, new Territory(163, "Romania") },
            { Territories.GHA, new Territory(164, "Ghana") },
            { Territories.UGA, new Territory(165, "Uganda") },
            { Territories.GBR, new Territory(166, "United Kingdom", null, null,
                new string[]{"Scotland", "Great Britain", "Northern Ireland", "Ireland, Northern"}) },
            { Territories.GIN, new Territory(167, "Guinea") },
            { Territories.ECU, new Territory(168, "Ecuador") },
            { Territories.ESH, new Territory(169, "Western Sahara", null, null, new string[]{"Sahrawi"}) },
            { Territories.GAB, new Territory(170, "Gabon") },
            { Territories.NZL, new Territory(171, "New Zealand") },
            { Territories.BFA, new Territory(172, "Burkina Faso") },
            { Territories.PHL, new Territory(173, "Philippines") },
            { Territories.ITA, new Territory(174, "Italy") },
            { Territories.OMN, new Territory(175, "Oman") },
            { Territories.POL, new Territory(176, "Poland") },
            { Territories.CIV, new Territory(177, "Ivory Coast") },
            { Territories.NOR, new Territory(178, "Norway") },
            { Territories.MYS, new Territory(179, "Malaysia") },
            { Territories.VNM, new Territory(180, "Vietnam") },
            { Territories.FIN, new Territory(181, "Finland") },
            { Territories.COG, new Territory(182, "Congo-Brazzaville") },
            { Territories.DEU, new Territory(183, "Germany") },
            { Territories.JPN, new Territory(184, "Japan") },
            { Territories.ZWE, new Territory(185, "Zimbabwe") },
            { Territories.PRY, new Territory(186, "Paraguay") },
            { Territories.IRQ, new Territory(187, "Iraq") },
            { Territories.MAR, new Territory(188, "Morocco") },
            { Territories.UZB, new Territory(189, "Uzbekistan") },
            { Territories.SWE, new Territory(190, "Sweden") },
            { Territories.PNG, new Territory(191, "Papua New Guinea") },
            { Territories.CMR, new Territory(192, "Cameroon") },
            { Territories.TKM, new Territory(193, "Turkmenistan") },
            { Territories.ESP, new Territory(194, "Spain") },
            { Territories.THA, new Territory(195, "Thailand") },
            { Territories.YEM, new Territory(196, "Yemen") },
            { Territories.FRA, new Territory(197, "France") },
            { Territories.ALA, new Territory(198, "Aaland Islands") },
            { Territories.KEN, new Territory(199, "Kenya") },
            { Territories.BWA, new Territory(200, "Botswana") },
            { Territories.MDG, new Territory(201, "Madagascar") },
            { Territories.UKR, new Territory(202, "Ukraine") },
            { Territories.SSD, new Territory(203, "South Sudan") },
            { Territories.CAF, new Territory(204, "Central African Republic") },
            { Territories.SOM, new Territory(205, "Somalia") },
            { Territories.AFG, new Territory(206, "Afghanistan") },
            { Territories.MMR, new Territory(207, "Myanmar", null, null, new string[]{"Burma"}) },
            { Territories.ZMB, new Territory(208, "Zambia") },
            { Territories.CHL, new Territory(209, "Chile") },
            { Territories.TUR, new Territory(210, "Turkey") },
            { Territories.PAK, new Territory(211, "Pakistan") },
            { Territories.MOZ, new Territory(212, "Mozambique") },
            { Territories.NAM, new Territory(213, "Namibia") },
            { Territories.VEN, new Territory(214, "Venezuela") },
            { Territories.NGA, new Territory(215, "Nigeria") },
            { Territories.TZA, new Territory(216, "Tanzania", null, new string[]{"EAZ"}) },
            { Territories.EGY, new Territory(217, "Egypt") },
            { Territories.MRT, new Territory(218, "Mauritania") },
            { Territories.BOL, new Territory(219, "Bolivia") },
            { Territories.ETH, new Territory(220, "Ethiopia") },
            { Territories.COL, new Territory(221, "Colombia") },
            { Territories.ZAF, new Territory(222, "South Africa") },
            { Territories.MLI, new Territory(223, "Mali") },
            { Territories.AGO, new Territory(224, "Angola") },
            { Territories.NER, new Territory(225, "Niger") },
            { Territories.TCD, new Territory(226, "Chad") },
            { Territories.PER, new Territory(227, "Peru") },
            { Territories.MNG, new Territory(228, "Mongolia") },
            { Territories.IRN, new Territory(229, "Iran") },
            { Territories.LBY, new Territory(230, "Libya") },
            { Territories.SDN, new Territory(231, "Sudan") },
            { Territories.IDN, new Territory(232, "Indonesia") },
            { Territories.MX_DIF, new Territory(233, "Federal District", ParentTerritories.MEX, new string[]{"MX-DF"}) },
            { Territories.MX_TLA, new Territory(234, "Tlaxcala", ParentTerritories.MEX, new string[]{"MX-TL"}) },
            { Territories.MX_MOR, new Territory(235, "Morelos", ParentTerritories.MEX, new string[]{"MX-MO"}) },
            { Territories.MX_AGU, new Territory(236, "Aguascalientes", ParentTerritories.MEX, new string[]{"MX-AG"}) },
            { Territories.MX_CL, new Territory(237, "Colima", ParentTerritories.MEX, new string[]{"MX-COL"}) },
            { Territories.MX_QUE, new Territory(238, "Queretaro", ParentTerritories.MEX, new string[]{"MX-QE"}) },
            { Territories.MX_HID, new Territory(239, "Hidalgo", ParentTerritories.MEX, new string[]{"MX-HG"}) },
            { Territories.MX_MX, new Territory(240, "Mexico State", ParentTerritories.MEX, new string[]{"MX-ME", "MX-MEX"}) },
            { Territories.MX_TAB, new Territory(241, "Tabasco", ParentTerritories.MEX, new string[]{"MX-TB"}) },
            { Territories.MX_NAY, new Territory(242, "Nayarit", ParentTerritories.MEX, new string[]{"MX-NA"}) },
            { Territories.MX_GUA, new Territory(243, "Guanajuato", ParentTerritories.MEX, new string[]{"MX-GT"}) },
            { Territories.MX_PUE, new Territory(244, "Puebla", ParentTerritories.MEX, new string[]{"MX-PB"}) },
            { Territories.MX_YUC, new Territory(245, "Yucatan", ParentTerritories.MEX, new string[]{"MX-YU"}) },
            { Territories.MX_ROO, new Territory(246, "Quintana Roo", ParentTerritories.MEX, new string[]{"MX-QR"}) },
            { Territories.MX_SIN, new Territory(247, "Sinaloa", ParentTerritories.MEX, new string[]{"MX-SI"}) },
            { Territories.MX_CAM, new Territory(248, "Campeche", ParentTerritories.MEX, new string[]{"MX-CM"}) },
            { Territories.MX_MIC, new Territory(249, "Michoacan", ParentTerritories.MEX, new string[]{"MX-MI"}) },
            { Territories.MX_SLP, new Territory(250, "San Luis Potosi", ParentTerritories.MEX, new string[]{"MX-SL"}) },
            { Territories.MX_GRO, new Territory(251, "Guerrero", ParentTerritories.MEX, new string[]{"MX-GR"}) },
            { Territories.MX_NLE, new Territory(252, "Nuevo Leon", ParentTerritories.MEX, new string[]{"MX-NL"}) },
            { Territories.MX_BCN, new Territory(253, "Baja California", ParentTerritories.MEX, new string[]{"MX-BC"}) },
            { Territories.MX_VER, new Territory(254, "Veracruz", ParentTerritories.MEX, new string[]{"MX-VE"}) },
            { Territories.MX_CHP, new Territory(255, "Chiapas", ParentTerritories.MEX, new string[]{"MX-CS"}) },
            { Territories.MX_BCS, new Territory(256, "Baja California Sur", ParentTerritories.MEX, new string[]{"MX-BS"}) },
            { Territories.MX_ZAC, new Territory(257, "Zacatecas", ParentTerritories.MEX, new string[]{"MX-ZA"}) },
            { Territories.MX_JAL, new Territory(258, "Jalisco", ParentTerritories.MEX, new string[]{"MX-JA"}) },
            { Territories.MX_TAM, new Territory(259, "Tamaulipas", ParentTerritories.MEX, new string[]{"MX-TM"}) },
            { Territories.MX_OAX, new Territory(260, "Oaxaca", ParentTerritories.MEX, new string[]{"MX-OA"}) },
            { Territories.MX_DUR, new Territory(261, "Durango", ParentTerritories.MEX, new string[]{"MX-DG"}) },
            { Territories.MX_COA, new Territory(262, "Coahuila", ParentTerritories.MEX, new string[]{"MX-CO"}) },
            { Territories.MX_SON, new Territory(263, "Sonora", ParentTerritories.MEX, new string[]{"MX-SO"}) },
            { Territories.MX_CHH, new Territory(264, "Chihuahua", ParentTerritories.MEX, new string[]{"MX-CH"}) },
            { Territories.GRL, new Territory(265, "Greenland") },
            { Territories.SAU, new Territory(266, "Saudi Arabia") },
            { Territories.COD, new Territory(267, "Congo-Kinshasa") },
            { Territories.DZA, new Territory(268, "Algeria") },
            { Territories.KAZ, new Territory(269, "Kazakhstan") },
            { Territories.ARG, new Territory(270, "Argentina") },
            { Territories.IN_DD, new Territory(271, "Daman and Diu", ParentTerritories.IND) },
            { Territories.IN_DN, new Territory(272, "Dadra and Nagar Haveli", ParentTerritories.IND) },
            { Territories.IN_CH, new Territory(273, "Chandigarh", ParentTerritories.IND) },
            { Territories.IN_AN, new Territory(274, "Andaman and Nicobar", ParentTerritories.IND) },
            { Territories.IN_LD, new Territory(275, "Lakshadweep", ParentTerritories.IND) },
            { Territories.IN_DL, new Territory(276, "Delhi", ParentTerritories.IND) },
            { Territories.IN_ML, new Territory(277, "Meghalaya", ParentTerritories.IND) },
            { Territories.IN_NL, new Territory(278, "Nagaland", ParentTerritories.IND) },
            { Territories.IN_MN, new Territory(279, "Manipur", ParentTerritories.IND) },
            { Territories.IN_TR, new Territory(280, "Tripura", ParentTerritories.IND) },
            { Territories.IN_MZ, new Territory(281, "Mizoram", ParentTerritories.IND) },
            { Territories.IN_SK, new Territory(282, "Sikkim", ParentTerritories.IND, new string[]{"IN-SKM"}) },
            { Territories.IN_PB, new Territory(283, "Punjab", ParentTerritories.IND) },
            { Territories.IN_HR, new Territory(284, "Haryana", ParentTerritories.IND) },
            { Territories.IN_AR, new Territory(285, "Arunachal Pradesh", ParentTerritories.IND) },
            { Territories.IN_AS, new Territory(286, "Assam", ParentTerritories.IND) },
            { Territories.IN_BR, new Territory(287, "Bihar", ParentTerritories.IND) },
            { Territories.IN_UT, new Territory(288, "Uttarakhand", ParentTerritories.IND, new string[]{"IN-UK"}) },
            { Territories.IN_GA, new Territory(289, "Goa", ParentTerritories.IND) },
            { Territories.IN_KL, new Territory(290, "Kerala", ParentTerritories.IND) },
            { Territories.IN_TN, new Territory(291, "Tamil Nuda", ParentTerritories.IND) },
            { Territories.IN_HP, new Territory(292, "Himachal Pradesh", ParentTerritories.IND) },
            { Territories.IN_JK, new Territory(293, "Jammu and Kashmir", ParentTerritories.IND) },
            { Territories.IN_CT, new Territory(294, "Chhattisgarh", ParentTerritories.IND, new string[]{"IN-CG"}) },
            { Territories.IN_JH, new Territory(295, "Jharkhand", ParentTerritories.IND) },
            { Territories.IN_KA, new Territory(296, "Karnataka", ParentTerritories.IND) },
            { Territories.IN_RJ, new Territory(297, "Rajasthan", ParentTerritories.IND) },
            { Territories.IN_OR, new Territory(298, "Odisha", ParentTerritories.IND, new string[]{"IN-OD"}, new string[]{"Orissa"}) },
            { Territories.IN_GJ, new Territory(299, "Gujarat", ParentTerritories.IND) },
            { Territories.IN_WB, new Territory(300, "West Bengal", ParentTerritories.IND) },
            { Territories.IN_MP, new Territory(301, "Madhya Pradesh", ParentTerritories.IND) },
            { Territories.IN_TG, new Territory(302, "Telangana", ParentTerritories.IND) },
            { Territories.IN_AP, new Territory(303, "Andhra Pradesh", ParentTerritories.IND) },
            { Territories.IN_MH, new Territory(304, "Maharashtra", ParentTerritories.IND) },
            { Territories.IN_UP, new Territory(305, "Uttar Pradesh", ParentTerritories.IND) },
            { Territories.IN_PY, new Territory(306, "Puducherry", ParentTerritories.IND) },
            { Territories.AU_NSW, new Territory(307, "New South Wales", ParentTerritories.AUS) },
            { Territories.AU_ACT, new Territory(308, "Australian Capital Territory", ParentTerritories.AUS) },
            { Territories.AU_JBT, new Territory(309, "Jervis Bay Territory", ParentTerritories.AUS, new string[]{"AU-JB"}) },
            { Territories.AU_NT, new Territory(310, "Northern Territory", ParentTerritories.AUS) },
            { Territories.AU_SA, new Territory(311, "South Australia", ParentTerritories.AUS) },
            { Territories.AU_TAS, new Territory(312, "Tasmania", ParentTerritories.AUS, new string[]{"AU-TS"}) },
            { Territories.AU_VIC, new Territory(313, "Victoria", ParentTerritories.AUS) },
            { Territories.AU_WA, new Territory(314, "Western Australia", ParentTerritories.AUS) },
            { Territories.AU_QLD, new Territory(315, "Queensland", ParentTerritories.AUS, new string[]{"AU-QL"}) },
            { Territories.BR_DF, new Territory(316, "Distrito Federal", ParentTerritories.BRA) },
            { Territories.BR_SE, new Territory(317, "Sergipe", ParentTerritories.BRA) },
            { Territories.BR_AL, new Territory(318, "Alagoas", ParentTerritories.BRA) },
            { Territories.BR_RJ, new Territory(319, "Rio de Janeiro", ParentTerritories.BRA) },
            { Territories.BR_ES, new Territory(320, "Espirito Santo", ParentTerritories.BRA) },
            { Territories.BR_RN, new Territory(321, "Rio Grande do Norte", ParentTerritories.BRA) },
            { Territories.BR_PB, new Territory(322, "Paraiba", ParentTerritories.BRA) },
            { Territories.BR_SC, new Territory(323, "Santa Catarina", ParentTerritories.BRA) },
            { Territories.BR_PE, new Territory(324, "Pernambuco", ParentTerritories.BRA) },
            { Territories.BR_AP, new Territory(325, "Amapa", ParentTerritories.BRA) },
            { Territories.BR_CE, new Territory(326, "Ceara", ParentTerritories.BRA) },
            { Territories.BR_AC, new Territory(327, "Acre", ParentTerritories.BRA) },
            { Territories.BR_PR, new Territory(328, "Parana", ParentTerritories.BRA) },
            { Territories.BR_RR, new Territory(329, "Roraima", ParentTerritories.BRA) },
            { Territories.BR_RO, new Territory(330, "Rondonia", ParentTerritories.BRA) },
            { Territories.BR_SP, new Territory(331, "Sao Paulo", ParentTerritories.BRA) },
            { Territories.BR_PI, new Territory(332, "Piaui", ParentTerritories.BRA) },
            { Territories.BR_TO, new Territory(333, "Tocantins", ParentTerritories.BRA) },
            { Territories.BR_RS, new Territory(334, "Rio Grande do Sul", ParentTerritories.BRA) },
            { Territories.BR_MA, new Territory(335, "Maranhao", ParentTerritories.BRA) },
            { Territories.BR_GO, new Territory(336, "Goias", ParentTerritories.BRA) },
            { Territories.BR_MS, new Territory(337, "Mato Grosso do Sul", ParentTerritories.BRA) },
            { Territories.BR_BA, new Territory(338, "Bahia", ParentTerritories.BRA) },
            { Territories.BR_MG, new Territory(339, "Minas Gerais", ParentTerritories.BRA) },
            { Territories.BR_MT, new Territory(340, "Mato Grosso", ParentTerritories.BRA) },
            { Territories.BR_PA, new Territory(341, "Para", ParentTerritories.BRA) },
            { Territories.BR_AM, new Territory(342, "Amazonas", ParentTerritories.BRA) },
            { Territories.US_DC, new Territory(343, "District of Columbia", ParentTerritories.USA) },
            { Territories.US_RI, new Territory(344, "Rhode Island", ParentTerritories.USA) },
            { Territories.US_DE, new Territory(345, "Delaware", ParentTerritories.USA) },
            { Territories.US_CT, new Territory(346, "Connecticut", ParentTerritories.USA) },
            { Territories.US_NJ, new Territory(347, "New Jersey", ParentTerritories.USA) },
            { Territories.US_NH, new Territory(348, "New Hampshire", ParentTerritories.USA) },
            { Territories.US_VT, new Territory(349, "Vermont", ParentTerritories.USA) },
            { Territories.US_MA, new Territory(350, "Massachusetts", ParentTerritories.USA) },
            { Territories.US_HI, new Territory(351, "Hawaii", ParentTerritories.USA, new string[]{"US-MID"}) },
            { Territories.US_MD, new Territory(352, "Maryland", ParentTerritories.USA) },
            { Territories.US_WV, new Territory(353, "West Virginia", ParentTerritories.USA) },
            { Territories.US_SC, new Territory(354, "South Carolina", ParentTerritories.USA) },
            { Territories.US_ME, new Territory(355, "Maine", ParentTerritories.USA) },
            { Territories.US_IN, new Territory(356, "Indiana", ParentTerritories.USA) },
            { Territories.US_KY, new Territory(357, "Kentucky", ParentTerritories.USA) },
            { Territories.US_TN, new Territory(358, "Tennessee", ParentTerritories.USA) },
            { Territories.US_VA, new Territory(359, "Virginia", ParentTerritories.USA) },
            { Territories.US_OH, new Territory(360, "Ohio", ParentTerritories.USA) },
            { Territories.US_PA, new Territory(361, "Pennsylvania", ParentTerritories.USA) },
            { Territories.US_MS, new Territory(362, "Mississippi", ParentTerritories.USA) },
            { Territories.US_LA, new Territory(363, "Louisiana", ParentTerritories.USA) },
            { Territories.US_AL, new Territory(364, "Alabama", ParentTerritories.USA) },
            { Territories.US_AR, new Territory(365, "Arkansas", ParentTerritories.USA) },
            { Territories.US_NC, new Territory(366, "North Carolina", ParentTerritories.USA) },
            { Territories.US_NY, new Territory(367, "New York", ParentTerritories.USA) },
            { Territories.US_IA, new Territory(368, "Iowa", ParentTerritories.USA) },
            { Territories.US_IL, new Territory(369, "Illinois", ParentTerritories.USA) },
            { Territories.US_GA, new Territory(370, "Georgia", ParentTerritories.USA) },
            { Territories.US_WI, new Territory(371, "Wisconsin", ParentTerritories.USA) },
            { Territories.US_FL, new Territory(372, "Florida", ParentTerritories.USA) },
            { Territories.US_MO, new Territory(373, "Missouri", ParentTerritories.USA) },
            { Territories.US_OK, new Territory(374, "Oklahoma", ParentTerritories.USA) },
            { Territories.US_ND, new Territory(375, "North Dakota", ParentTerritories.USA) },
            { Territories.US_WA, new Territory(376, "Washington", ParentTerritories.USA) },
            { Territories.US_SD, new Territory(377, "South Dakota", ParentTerritories.USA) },
            { Territories.US_NE, new Territory(378, "Nebraska", ParentTerritories.USA) },
            { Territories.US_KS, new Territory(379, "Kansas", ParentTerritories.USA) },
            { Territories.US_ID, new Territory(380, "Idaho", ParentTerritories.USA) },
            { Territories.US_UT, new Territory(381, "Utah", ParentTerritories.USA) },
            { Territories.US_MN, new Territory(382, "Minnesota", ParentTerritories.USA) },
            { Territories.US_MI, new Territory(383, "Michigan", ParentTerritories.USA) },
            { Territories.US_WY, new Territory(384, "Wyoming", ParentTerritories.USA) },
            { Territories.US_OR, new Territory(385, "Oregon", ParentTerritories.USA) },
            { Territories.US_CO, new Territory(386, "Colorado", ParentTerritories.USA) },
            { Territories.US_NV, new Territory(387, "Nevada", ParentTerritories.USA) },
            { Territories.US_AZ, new Territory(388, "Arizona", ParentTerritories.USA) },
            { Territories.US_NM, new Territory(389, "New Mexico", ParentTerritories.USA) },
            { Territories.US_MT, new Territory(390, "Montana", ParentTerritories.USA) },
            { Territories.US_CA, new Territory(391, "California", ParentTerritories.USA) },
            { Territories.US_TX, new Territory(392, "Texas", ParentTerritories.USA) },
            { Territories.US_AK, new Territory(393, "Alaska", ParentTerritories.USA) },
            { Territories.CA_BC, new Territory(394, "British Columbia", ParentTerritories.CAN) },
            { Territories.CA_AB, new Territory(395, "Alberta", ParentTerritories.CAN) },
            { Territories.CA_ON, new Territory(396, "Ontario", ParentTerritories.CAN) },
            { Territories.CA_QC, new Territory(397, "Quebec", ParentTerritories.CAN) },
            { Territories.CA_SK, new Territory(398, "Saskatchewan", ParentTerritories.CAN) },
            { Territories.CA_MB, new Territory(399, "Manitoba", ParentTerritories.CAN) },
            { Territories.CA_NL, new Territory(400, "Newfoundland", ParentTerritories.CAN) },
            { Territories.CA_NB, new Territory(401, "New Brunswick", ParentTerritories.CAN) },
            { Territories.CA_NS, new Territory(402, "Nova Scotia", ParentTerritories.CAN) },
            { Territories.CA_PE, new Territory(403, "Prince Edward Island", ParentTerritories.CAN) },
            { Territories.CA_YT, new Territory(404, "Yukon", ParentTerritories.CAN) },
            { Territories.CA_NT, new Territory(405, "Northwest Territories", ParentTerritories.CAN) },
            { Territories.CA_NU, new Territory(406, "Nunavut", ParentTerritories.CAN) },
            { Territories.RU_MOW, new Territory(412, "Moscow", ParentTerritories.RUS) },
            { Territories.RU_SPE, new Territory(413, "Saint Petersburg", ParentTerritories.RUS) },
            { Territories.RU_KGD, new Territory(414, "Kaliningrad Oblast", ParentTerritories.RUS) },
            { Territories.RU_IN, new Territory(415, "Ingushetia Republic", ParentTerritories.RUS) },
            { Territories.RU_AD, new Territory(416, "Adygea Republic", ParentTerritories.RUS) },
            { Territories.RU_SE, new Territory(417, "North Ossetia-Alania Republic", ParentTerritories.RUS) },
            { Territories.RU_KB, new Territory(418, "Kabardino-Balkar Republic", ParentTerritories.RUS) },
            { Territories.RU_KC, new Territory(419, "Karachay-Cherkess Republic", ParentTerritories.RUS) },
            { Territories.RU_CE, new Territory(420, "Chechen Republic", ParentTerritories.RUS) },
            { Territories.RU_CU, new Territory(421, "Chuvash Republic", ParentTerritories.RUS) },
            { Territories.RU_IVA, new Territory(422, "Ivanovo Oblast", ParentTerritories.RUS) },
            { Territories.RU_LIP, new Territory(423, "Lipetsk Oblast", ParentTerritories.RUS) },
            { Territories.RU_ORL, new Territory(424, "Oryol Oblast", ParentTerritories.RUS) },
            { Territories.RU_TUL, new Territory(425, "Tula Oblast", ParentTerritories.RUS) },
            { Territories.RU_BE, new Territory(426, "Belgorod Oblast", ParentTerritories.RUS, new string[]{"RU-BEL"}) },
            { Territories.RU_VLA, new Territory(427, "Vladimir Oblast", ParentTerritories.RUS) },
            { Territories.RU_KRS, new Territory(428, "Kursk Oblast", ParentTerritories.RUS) },
            { Territories.RU_KLU, new Territory(429, "Kaluga Oblast", ParentTerritories.RUS) },
            { Territories.RU_TT, new Territory(430, "Tambov Oblast", ParentTerritories.RUS, new string[]{"RU-TAM"}) },
            { Territories.RU_BRY, new Territory(431, "Bryansk Oblast", ParentTerritories.RUS) },
            { Territories.RU_YAR, new Territory(432, "Yaroslavl Oblast", ParentTerritories.RUS) },
            { Territories.RU_RYA, new Territory(433, "Ryazan Oblast", ParentTerritories.RUS) },
            { Territories.RU_AST, new Territory(434, "Astrakhan Oblast", ParentTerritories.RUS) },
            { Territories.RU_MOS, new Territory(435, "Moscow Oblast", ParentTerritories.RUS) },
            { Territories.RU_SMO, new Territory(436, "Smolensk Oblast", ParentTerritories.RUS) },
            { Territories.RU_DA, new Territory(437, "Dagestan Republic", ParentTerritories.RUS) },
            { Territories.RU_VOR, new Territory(438, "Voronezh Oblast", ParentTerritories.RUS) },
            { Territories.RU_NGR, new Territory(439, "Novgorod Oblast", ParentTerritories.RUS) },
            { Territories.RU_PSK, new Territory(440, "Pskov Oblast", ParentTerritories.RUS) },
            { Territories.RU_KOS, new Territory(441, "Kostroma Oblast", ParentTerritories.RUS) },
            { Territories.RU_STA, new Territory(442, "Stavropol Krai", ParentTerritories.RUS) },
            { Territories.RU_KDA, new Territory(443, "Krasnodar Krai", ParentTerritories.RUS) },
            { Territories.RU_KL, new Territory(444, "Kalmykia Republic", ParentTerritories.RUS) },
            { Territories.RU_TVE, new Territory(445, "Tver Oblast", ParentTerritories.RUS) },
            { Territories.RU_LEN, new Territory(446, "Leningrad Oblast", ParentTerritories.RUS) },
            { Territories.RU_ROS, new Territory(447, "Rostov Oblast", ParentTerritories.RUS) },
            { Territories.RU_VGG, new Territory(448, "Volgograd Oblast", ParentTerritories.RUS) },
            { Territories.RU_VLG, new Territory(449, "Vologda Oblast", ParentTerritories.RUS) },
            { Territories.RU_MUR, new Territory(450, "Murmansk Oblast", ParentTerritories.RUS) },
            { Territories.RU_KR, new Territory(451, "Karelia Republic", ParentTerritories.RUS) },
            { Territories.RU_NEN, new Territory(452, "Nenets Autonomous Okrug", ParentTerritories.RUS) },
            { Territories.RU_KO, new Territory(453, "Komi Republic", ParentTerritories.RUS) },
            { Territories.RU_ARK, new Territory(454, "Arkhangelsk Oblast", ParentTerritories.RUS) },
            { Territories.RU_MO, new Territory(455, "Mordovia Republic", ParentTerritories.RUS) },
            { Territories.RU_NIZ, new Territory(456, "Nizhny Novgorod Oblast", ParentTerritories.RUS) },
            { Territories.RU_PNZ, new Territory(457, "Penza Oblast", ParentTerritories.RUS) },
            { Territories.RU_KI, new Territory(458, "Kirov Oblast", ParentTerritories.RUS, new string[]{"RU-KIR"}) },
            { Territories.RU_ME, new Territory(459, "Mari El Republic", ParentTerritories.RUS) },
            { Territories.RU_ORE, new Territory(460, "Orenburg Oblast", ParentTerritories.RUS) },
            { Territories.RU_ULY, new Territory(461, "Ulyanovsk Oblast", ParentTerritories.RUS) },
            { Territories.RU_PM, new Territory(462, "Perm Krai", ParentTerritories.RUS, new string[]{"RU-PER"}) },
            { Territories.RU_BA, new Territory(463, "Bashkortostan Republic", ParentTerritories.RUS) },
            { Territories.RU_UD, new Territory(464, "Udmurt Republic", ParentTerritories.RUS) },
            { Territories.RU_TA, new Territory(465, "Tatarstan Republic", ParentTerritories.RUS) },
            { Territories.RU_SAM, new Territory(466, "Samara Oblast", ParentTerritories.RUS) },
            { Territories.RU_SAR, new Territory(467, "Saratov Oblast", ParentTerritories.RUS) },
            { Territories.RU_YAN, new Territory(468, "Yamalo-Nenets", ParentTerritories.RUS) },
            { Territories.RU_KM, new Territory(469, "Khanty-Mansi", ParentTerritories.RUS, new string[]{"RU-KHM"}) },
            { Territories.RU_SVE, new Territory(470, "Sverdlovsk Oblast", ParentTerritories.RUS) },
            { Territories.RU_TYU, new Territory(471, "Tyumen Oblast", ParentTerritories.RUS) },
            { Territories.RU_KGN, new Territory(472, "Kurgan Oblast", ParentTerritories.RUS) },
            { Territories.RU_CH, new Territory(473, "Chelyabinsk Oblast", ParentTerritories.RUS, new string[]{"RU-CHE"}) },
            { Territories.RU_BU, new Territory(474, "Buryatia Republic", ParentTerritories.RUS) },
            { Territories.RU_ZAB, new Territory(475, "Zabaykalsky Krai", ParentTerritories.RUS) },
            { Territories.RU_IRK, new Territory(476, "Irkutsk Oblast", ParentTerritories.RUS) },
            { Territories.RU_NVS, new Territory(477, "Novosibirsk Oblast", ParentTerritories.RUS) },
            { Territories.RU_TOM, new Territory(478, "Tomsk Oblast", ParentTerritories.RUS) },
            { Territories.RU_OMS, new Territory(479, "Omsk Oblast", ParentTerritories.RUS) },
            { Territories.RU_KK, new Territory(480, "Khakassia Republic", ParentTerritories.RUS) },
            { Territories.RU_KEM, new Territory(481, "Kemerovo Oblast", ParentTerritories.RUS) },
            { Territories.RU_AL, new Territory(482, "Altai Republic", ParentTerritories.RUS) },
            { Territories.RU_ALT, new Territory(483, "Altai Krai", ParentTerritories.RUS) },
            { Territories.RU_TY, new Territory(484, "Tuva Republic", ParentTerritories.RUS) },
            { Territories.RU_KYA, new Territory(485, "Krasnoyarsk Krai", ParentTerritories.RUS) },
            { Territories.RU_MAG, new Territory(486, "Magadan Oblast", ParentTerritories.RUS) },
            { Territories.RU_CHU, new Territory(487, "Chukotka Okrug", ParentTerritories.RUS) },
            { Territories.RU_KAM, new Territory(488, "Kamchatka Krai", ParentTerritories.RUS) },
            { Territories.RU_SAK, new Territory(489, "Sakhalin Oblast", ParentTerritories.RUS) },
            { Territories.RU_PO, new Territory(490, "Primorsky Krai", ParentTerritories.RUS, new string[]{"RU-PRI"}) },
            { Territories.RU_YEV, new Territory(491, "Jewish Autonomous Oblast", ParentTerritories.RUS) },
            { Territories.RU_KHA, new Territory(492, "Khabarovsk Krai", ParentTerritories.RUS) },
            { Territories.RU_AMU, new Territory(493, "Amur Oblast", ParentTerritories.RUS) },
            { Territories.RU_SA, new Territory(494, "Sakha Republic", ParentTerritories.RUS, null, new string[]{"Yakutia Republic"}) },
            { Territories.CN_SH, new Territory(497, "Shanghai", ParentTerritories.CHN, new string[]{"CN-31"}) },
            { Territories.CN_TJ, new Territory(498, "Tianjin", ParentTerritories.CHN, new string[]{"CN-12"}) },
            { Territories.CN_BJ, new Territory(499, "Beijing", ParentTerritories.CHN, new string[]{"CN-11"}) },
            { Territories.CN_HI, new Territory(500, "Hainan", ParentTerritories.CHN, new string[]{"CN-46"}) },
            { Territories.CN_NX, new Territory(501, "Ningxia Hui", ParentTerritories.CHN, new string[]{"CN-64"}) },
            { Territories.CN_CQ, new Territory(502, "Chongqing", ParentTerritories.CHN, new string[]{"CN-50"}) },
            { Territories.CN_ZJ, new Territory(503, "Zhejiang", ParentTerritories.CHN, new string[]{"CN-33"}) },
            { Territories.CN_JS, new Territory(504, "Jiangsu", ParentTerritories.CHN, new string[]{"CN-32"}) },
            { Territories.CN_FJ, new Territory(505, "Fujian", ParentTerritories.CHN, new string[]{"CN-35"}) },
            { Territories.CN_AH, new Territory(506, "Anhui", ParentTerritories.CHN, new string[]{"CN-34"}) },
            { Territories.CN_LN, new Territory(507, "Liaoning", ParentTerritories.CHN, new string[]{"CN-21"}) },
            { Territories.CN_SD, new Territory(508, "Shandong", ParentTerritories.CHN, new string[]{"CN-37"}) },
            { Territories.CN_SX, new Territory(509, "Shanxi", ParentTerritories.CHN, new string[]{"CN-14"}) },
            { Territories.CN_JX, new Territory(510, "Jiangxi", ParentTerritories.CHN, new string[]{"CN-36"}) },
            { Territories.CN_HA, new Territory(511, "Henan", ParentTerritories.CHN, new string[]{"CN-41"}) },
            { Territories.CN_GZ, new Territory(512, "Guizhou", ParentTerritories.CHN, new string[]{"CN-52"}) },
            { Territories.CN_GD, new Territory(513, "Guangdong", ParentTerritories.CHN, new string[]{"CN-44"}) },
            { Territories.CN_HB, new Territory(514, "Hubei", ParentTerritories.CHN, new string[]{"CN-42"}) },
            { Territories.CN_JL, new Territory(515, "Jilin", ParentTerritories.CHN, new string[]{"CN-22"}) },
            { Territories.CN_HE, new Territory(516, "Hebei", ParentTerritories.CHN, new string[]{"CN-13"}) },
            { Territories.CN_SN, new Territory(517, "Shaanxi", ParentTerritories.CHN, new string[]{"CN-61"}) },
            { Territories.CN_NM, new Territory(518, "Nei Mongol", ParentTerritories.CHN, new string[]{"CN-15"}, new string[]{"Inner Mongolia"}) },
            { Territories.CN_HL, new Territory(519, "Heilongjiang", ParentTerritories.CHN, new string[]{"CN-23"}) },
            { Territories.CN_HN, new Territory(520, "Hunan", ParentTerritories.CHN, new string[]{"CN-43"}) },
            { Territories.CN_GX, new Territory(521, "Guangxi Zhuang", ParentTerritories.CHN, new string[]{"CN-45"}) },
            { Territories.CN_SC, new Territory(522, "Sichuan", ParentTerritories.CHN, new string[]{"CN-51"}) },
            { Territories.CN_YN, new Territory(523, "Yunnan", ParentTerritories.CHN, new string[]{"CN-53"}) },
            { Territories.CN_XZ, new Territory(524, "Xizang", ParentTerritories.CHN, new string[]{"CN-54"}, new string[]{"Tibet"}) },
            { Territories.CN_GS, new Territory(525, "Gansu", ParentTerritories.CHN, new string[]{"CN-62"}) },
            { Territories.CN_QH, new Territory(526, "Qinghai", ParentTerritories.CHN, new string[]{"CN-63"}) },
            { Territories.CN_XJ, new Territory(527, "Xinjiang Uyghur", ParentTerritories.CHN, new string[]{"CN-65"}) },
            { Territories.UMI, new Territory(529, "United States Minor Outlying Islands", null, new string[]{"US-UM", "USA-UM", "JTN"}) },
            { Territories.CPT, new Territory(530, "Clipperton Island") },
            { Territories.AT0, new Territory(531, "Macquarie Island", ParentTerritories.ATA) },
            { Territories.AT1, new Territory(532, "Ross Dependency", ParentTerritories.ATA) },
            { Territories.AT2, new Territory(533, "Adelie Land", ParentTerritories.ATA) },
            { Territories.AT3, new Territory(534, "Australian Antarctic Territory", ParentTerritories.ATA) },
            { Territories.AT4, new Territory(535, "Queen Maud Land", ParentTerritories.ATA) },
            { Territories.AT5, new Territory(536, "British Antarctic Territory", ParentTerritories.ATA) },
            { Territories.AT6, new Territory(537, "Chile Antartica", ParentTerritories.ATA) },
            { Territories.AT7, new Territory(538, "Argentine Antarctica", ParentTerritories.ATA) },
            { Territories.AT8, new Territory(539, "Peter 1 Island", ParentTerritories.ATA) },
            { Territories.AAA, new Territory(541, "International", null, null, new string[]{"Worldwide", "Earth"}) }
        };

        /// <summary>
        /// Return the numeric territory code for a territory.
        /// </summary>
        /// <returns>Integer territory code.</returns>
        public int getTerritoryCode()
        {
            return territoryCode;
        }

        /**
         * Return the full name of the territory.
         *
         * @return Full name.
         */
        public string getFullName()
        {
            return fullName;
        }

        /**
         * Return aliases (if any) for a territory. If there are no aliases, the array is empty.
         *
         * @return Aliases. Empty if no aliases exist.
         */
        public string[] getAliases()
        {
            return aliases;
        }

        /**
         * Return the parent territory.
         *
         * @return Parent territory for this territory. Null if no parent territory exists.
         */
        public Territory getParentTerritory()
        {
            return ParentTerritory;
        }

        /**
         * Return aliases (if any) for the full name of a territory. If there are no aliases, the array is empty.
         *
         * @return Aliases. Empty if no aliases exist.
         */
        public String[] getFullNameAliases()
        {
            return fullNameAliases;
        }

        /**
         * Return the territory for a specific code.
         *
         * @param territoryCode Numeric territory code.
         * @return Territory.
         */
        public static Territory fromTerritoryCode(int territoryCode)
        {
            CheckArgs.checkRange("territoryCode", territoryCode, 0, codeList.Count - 1);
            return codeList[territoryCode];
        }

        /**
         * Get a territory from a mapcode territory abbreviation. Note that the provided abbreviation is NOT an
         * ISO code: it's a mapcode prefix. As local mapcodes for states have been optimized to prefer to use 2-character
         * state codes in local codes, states are preferred over countries in this case.
         *
         * For example, fromString("AS") returns {@link Territory#IN_AS} rather than {@link Territory#ASM} and
         * fromString("BR") returns {@link Territory#IN_BR} rather than {@link Territory#BRA}.
         *
         * This behavior is intentional as local mapcodes are designed to be as short as possible. A mapcode within
         * the Indian state Bihar should therefore be able to specified as "BR 49.46M3" rather "IN-BR 49.46M3".
         *
         * Brazilian mapcodes, on the other hand, would be specified as "BRA BDHP.JK39-1D", using the ISO 3 letter code.
         *
         * @param name Territory name.
         * @return Territory.
         * @throws UnknownTerritoryException Thrown if the territory is not found.
         */
        public static Territory fromString(string name) // throws UnknownTerritoryException
        {
            CheckArgs.checkNonnull("name", name);
            return createFromString(name, null);
        }

        /**
         * Get a territory from a name, specifying a parent territory for disambiguation.
         *
         * @param name            Territory name. See {@link #fromString(String)} for an explanation of the format for
         *                        this name. (This is NOT strictly an ISO code!)
         * @param parentTerritory Parent territory.
         * @return Territory.
         * @throws UnknownTerritoryException Thrown if the territory is not found given the ParentTerritories.
         */
        public static Territory fromString(string name, ParentTerritory parentTerritory) // throws UnknownTerritoryException
        {
            CheckArgs.checkNonnull("name", name);
            CheckArgs.checkNonnull("parentTerritory", parentTerritory);
            return createFromString(name, parentTerritory);
        }

        /**
         * Return the territory name.
         *
         * @return Territory name. Same as toNameFormat(NameFormat.INTERNATIONAL).
         */
        public override string ToString()
        {
            // Territory names contain "-". Enum constants must have this
            // substituted to "_"
            return fullName.Replace('_', '-'); // name()
        }

        /**
         * Return the territory name, given a specific territory name format.
         *
         * @param format Format to be used.
         * @return Mapcode
         */
        public string toNameFormat(NameFormat format)
        {
            CheckArgs.checkNonnull("format", format);
            if (format != NameFormat.INTERNATIONAL)
            {
                int index = fullName.IndexOf('_'); // name()
                if (index != -1)
                {
                    System.Diagnostics.Debug.Assert(fullName.Length > (index + 1));
                    string shortName = fullName.Substring(index + 1);
                    if ((format == NameFormat.MINIMAL) || nameMap.ContainsKey(shortName))
                    {
                        return shortName;
                    }
                }
            }
            return ToString();
        }

        /**
         * Returns if this territory is a state of another territory.
         *
         * @return True if this territory has a parent territory.
         */
        public bool isState()
        {
            return ParentTerritory != null;
        }

        /**
         * Returns if this territory contains other territory states.
         *
         * @return True if this territory contains other territory states.
         */
        public bool hasStates()
        {
            return parentList.Contains(this);
        }

        /**
         * Static initialization of the static data structures.
         */
        private static List<int> territoryCodeList = new List<int>();

        // ROBOCOP Find a way to call this first
        private static void Initialize()
        {
            int length = territories.Values.Count;
            foreach (Territory territory in territories.Values)
            {
                int territoryCode = territory.getTerritoryCode();
                System.Diagnostics.Debug.Assert((0 <= territoryCode) && (territoryCode < length));
                System.Diagnostics.Debug.Assert(!territoryCodeList.Contains(territoryCode));
                territoryCodeList.Add(territory.getTerritoryCode());

                int initialCodeListSize = codeList.Count;
                for (int i = initialCodeListSize; i <= territoryCode; i++)
                {
                    codeList.Add(null);
                }
                codeList[territoryCode] = territory;
                if ((territory.ParentTerritory != null) && !parentList.Contains(territory.ParentTerritory))
                {
                    parentList.Add(territory.ParentTerritory);
                }
                addNameWithParentVariants(territory.ToString(), territory);
                foreach (string alias in territory.aliases)
                {
                    addNameWithParentVariants(alias, territory);
                }
            }
            System.Diagnostics.Debug.Assert(territoryCodeList.Count == length);
        }

        /**
         * Get a territory from a name, specifying a parent territory for disambiguation.
         *
         * @param name            Territory name.
         * @param parentTerritory Parent territory.
         * @return Territory.
         * @throws UnknownTerritoryException Thrown if the territory is not found.
         */
        private static Territory createFromString(string name, ParentTerritory parentTerritory) // throws UnknownTerritoryException
        {
            string nameTrimmed = name.Trim();
            List<Territory> territories = nameMap[nameTrimmed];
            if (territories != null)
            {
                if (parentTerritory == null)
                {
                    return territories[0];
                }
                Territory actualParentTerritory = parentTerritory.getTerritory();
                foreach (Territory territory in territories)
                {
                    if (territory.getParentTerritory() == actualParentTerritory)
                    {
                        return territory;
                    }
                }
                throw new UnknownTerritoryException(nameTrimmed);
            }

            // Check for a case such as USA-NLD (=NLD)
            int dividerLocation = Math.Max(nameTrimmed.IndexOf('-'), nameTrimmed.IndexOf(' '));
            if (dividerLocation >= 0)
            {
                return createFromString(nameTrimmed.Substring(dividerLocation + 1), parentTerritory);
            }
            throw new UnknownTerritoryException(nameTrimmed);
        }

        /**
         * Private helper method to add names for a territory.
         *
         * @param name      Name to add.
         * @param territory Territory.
         */
        private static void addNameWithParentVariants(string name, Territory territory)
        {
            // Add the name as provided
            addNameWithSeperatorVariants(name, territory);

            if (name.Contains("-"))
            {
                string childTerritoryName = name.Substring(name.IndexOf('-') + 1);

                // Tolerate a child territory specified without the parent.
                // (e.g. "CA" rather than "US-CA")
                addName(childTerritoryName, territory);

                if (territory.ParentTerritory != null)
                {
                    // Add the variant using the primary parent name.
                    string nameVariant = (territory.ParentTerritory.ToString() + '-') + childTerritoryName;
                    if (nameVariant.CompareTo(name) != 0)
                    {
                        addNameWithSeperatorVariants(nameVariant, territory);
                    }

                    // Add each variant using the parent alias names.
                    foreach (string alias in territory.ParentTerritory.aliases)
                    {
                        nameVariant = alias + '-' + childTerritoryName;
                        if (nameVariant.CompareTo(name) != 0)
                        {
                            addNameWithSeperatorVariants(nameVariant, territory);
                        }
                    }
                }
            }
        }

        private static void addNameWithSeperatorVariants(string name, Territory territory)
        {
            addName(name, territory);

            // Tolerate a space character in place of a hyphen.
            // (e.g. "US CA" in addition to "US-CA")
            if (name.Contains("-"))
            {
                addName(name.Replace('-', ' '), territory);
            }
        }

        private static void addName(string name, Territory territory)
        {
            if (nameMap.ContainsKey(name))
            {
                List<Territory> territories = nameMap[name];

                // Add child territories in the order the parents are declared.
                // This results in consistent decoding of ambiguous territory names.
                Territory newTerritoryParent = territory.getParentTerritory();
                if ((newTerritoryParent == null) && name.CompareTo(territory.ToString()) == 0)
                {
                    // A primary identifier always takes priority.
                    territories.Clear();
                    territories.Add(territory);
                    return;
                }

                if (newTerritoryParent != null)
                {
                    for (int i = 0; i < territories.Count; i++)
                    {
                        Territory existingTerritoryParent = territories[i].getParentTerritory();
                        if (existingTerritoryParent == null && territories[i].ToString().CompareTo(name) == 0)
                        {
                            // A primary identifier always takes priority.
                            return;
                        }
                        if ((existingTerritoryParent == null) ||
                            (existingTerritoryParent.GetHashCode() > newTerritoryParent.GetHashCode()))
                        {
                            territories[i] = territory;
                            return;
                        }
                    }
                }
                territories.Add(territory);
            }
            else
            {
                List<Territory> arrayList = new List<Territory>();
                arrayList.Add(territory);
                nameMap[name] = arrayList;
            }
        }
    }
}
