using System.Collections.Frozen;

namespace Huawei.E3372.Manager.Logic.Constants;

public static class MobileCountyCodeConstants
{
    public static readonly IReadOnlyDictionary<string, string> MobileCountyCodeToTimeZoneId = new Dictionary<string, string>(StringComparer.Ordinal)
    {
        { "202", "Central Europe Standard Time" }, // Liechtenstein (Central Europe)
        { "204", "W. Europe Standard Time" }, // Netherlands (Western Europe)
        { "206", "Romance Standard Time" }, // Belgium (Western Europe)
        { "208", "W. Europe Standard Time" }, // Denmark (Western Europe)
        { "212", "W. Europe Standard Time" }, // Monaco (Western Europe)
        { "213", "W. Europe Standard Time" }, // Andorra (Western Europe)
        { "214", "Romance Standard Time" }, // Spain (Western Europe)
        { "216", "GMT Standard Time" }, // Ireland
        { "218", "GTB Standard Time" }, // Romania (Eastern Europe)
        { "219", "Central European Standard Time" }, // Montenegro (Central Europe)
        { "220", "Central European Standard Time" }, // Serbia (Central Europe)
        { "222", "W. Europe Standard Time" }, // Italy (Western Europe)
        { "228", "W. Europe Standard Time" }, // Switzerland (Central Europe)
        { "230", "Central Europe Standard Time" }, // Czech Republic (Central Europe)
        { "231", "Central European Standard Time" }, // Slovakia (Central Europe)
        { "232", "Central Europe Standard Time" }, // Austria (Central Europe)
        { "234", "GMT Standard Time" }, // United Kingdom
        { "235", "GMT Standard Time" }, // United Kingdom
        { "238", "W. Europe Standard Time" }, // Norway (Western Europe)
        { "240", "W. Europe Standard Time" }, // Sweden (Western Europe)
        { "242", "W. Europe Standard Time" }, // Sweden (Western Europe)
        { "244", "W. Europe Standard Time" }, // Finland (Southern - Helsinki)
        { "246", "FLE Standard Time" }, // Finland (Eastern parts)
        { "247", "Kaliningrad Standard Time" }, // Russia (Kaliningrad)
        { "248", "FLE Standard Time" }, // Åland Islands (Finland)
        { "250", "Russian Standard Time" }, // Russia (Most European part)
        { "255", "FLE Standard Time" }, // Ukraine (Most parts)
        { "257", "FLE Standard Time" }, // Estonia
        { "259", "Central Europe Standard Time" }, // Malta (Central Europe)
        { "260", "Central European Standard Time" }, // Poland (Central Europe)
        { "262", "W. Europe Standard Time" }, // Germany
        { "264", "Romance Standard Time" }, // Spain
        { "266", "GMT Standard Time" }, // Guernsey, Jersey
        { "268", "GMT Standard Time" }, // Portugal (Mainland)
        { "270", "W. Europe Standard Time" }, // Norway
        { "272", "Central European Standard Time" }, // Slovenia (Central Europe)
        { "274", "FLE Standard Time" }, // Latvia
        { "276", "Central Europe Standard Time" }, // Hungary (Central Europe)
        { "278", "FLE Standard Time" }, // Lithuania
        { "280", "GTB Standard Time" }, // Bulgaria (Eastern Europe)
        { "282", "Central European Standard Time" }, // Slovakia
        { "283", "Central European Standard Time" }, // Croatia (Central Europe)
        { "284", "Belarus Standard Time" }, // Belarus
        { "286", "Turkey Standard Time" }, // Turkey
        { "288", "E. Europe Standard Time" }, // Moldova
        { "290", "GMT Standard Time" }, // Gibraltar
        { "291", "Central European Standard Time" }, // Bosnia and Herzegovina
        { "292", "Central European Standard Time" }, // Albania
        { "293", "W. Europe Standard Time" }, // Luxembourg (Western Europe)
        { "294", "GTB Standard Time" }, // Greece
        { "295", "Central European Standard Time" }, // North Macedonia
        { "296", "Central European Standard Time" }, // Slovenia
        { "297", "GMT Standard Time" }, // Ireland (Northern)
        { "302", "Atlantic Standard Time" }, // Canada (Atlantic)
        { "303", "Pacific Standard Time" }, // Canada (West)
        { "305", "Atlantic Standard Time" }, // Canada (East)
        { "307", "Canada Central Standard Time" }, // Canada (Central)
        { "308", "Atlantic Standard Time" }, // Canada (East)
        { "310", "Pacific Standard Time" }, // USA (West Coast)
        { "311", "Pacific Standard Time" }, // USA (West Coast)
        { "312", "Mountain Standard Time" }, // USA (Mountain)
        { "313", "Eastern Standard Time" }, // Canada (East)
        { "314", "Eastern Standard Time" }, // USA (East Coast)
        { "315", "Central Standard Time" }, // USA (Central)
        { "316", "Central Standard Time" }, // Canada (Central)
        { "317", "Eastern Standard Time" }, // USA (Indiana)
        { "330", "Atlantic Standard Time" }, // Puerto Rico (Atlantic-like)
        { "334", "Mountain Standard Time" }, // Canada (Alberta)
        { "338", "Atlantic Standard Time" }, // Barbados
        { "340", "Atlantic Standard Time" }, // Antigua and Barbuda
        { "342", "Atlantic Standard Time" }, // Grenada
        { "344", "Atlantic Standard Time" }, // Saint Lucia
        { "346", "Atlantic Standard Time" }, // Saint Vincent and the Grenadines
        { "348", "Atlantic Standard Time" }, // Dominica
        { "350", "Atlantic Standard Time" }, // Trinidad and Tobago
        { "352", "Eastern Standard Time" }, // Bahamas (Eastern-like)
        { "354", "Eastern Standard Time" }, // Cayman Islands (Eastern-like)
        { "356", "Eastern Standard Time" }, // Turks and Caicos Islands (Eastern-like)
        { "360", "Alaskan Standard Time" }, // USA (Alaska)
        { "362", "Atlantic Standard Time" }, // Anguilla
        { "363", "Atlantic Standard Time" }, // Montserrat
        { "364", "Atlantic Standard Time" }, // Aruba
        { "365", "Atlantic Standard Time" }, // Curaçao
        { "366", "Atlantic Standard Time" }, // Bonaire
        { "372", "SA Pacific Standard Time" }, // Panama (Pacific side)
        { "400", "Azerbaijan Standard Time" }, // Azerbaijan
        { "401", "Caucasus Standard Time" }, // Armenia
        { "402", "Georgian Standard Time" }, // Georgia
        { "404", "Arabian Standard Time" }, // United Arab Emirates
        { "405", "Arabian Standard Time" }, // Oman
        { "406", "Arabic Standard Time" }, // Yemen
        { "410", "Arabian Standard Time" }, // Bahrain
        { "412", "Arabian Standard Time" }, // Qatar
        { "413", "Arab Standard Time" }, // Saudi Arabia
        { "414", "Arab Standard Time" }, // Kuwait
        { "415", "Arabic Standard Time" }, // Syria
        { "416", "Jordan Standard Time" }, // Jordan
        { "417", "Israel Standard Time" }, // Israel
        { "418", "Middle East Standard Time" }, // Lebanon
        { "419", "Arabian Standard Time" }, // Cyprus (Likely aligns with nearby zones)
        { "420", "Turkey Standard Time" }, // Turkey
        { "421", "Arabic Standard Time" }, // Iraq
        { "422", "Iran Standard Time" }, // Iran
        { "424", "West Asia Standard Time" }, // Uzbekistan (Tashkent)
        { "425", "West Asia Standard Time" }, // Turkmenistan
        { "426", "West Asia Standard Time" }, // Tajikistan
        { "427", "Central Asia Standard Time" }, // Kyrgyzstan
        { "428", "West Asia Standard Time" }, // Kazakhstan (Almaty)
        { "429", "Bangladesh Standard Time" }, // Bangladesh
        { "430", "Pakistan Standard Time" }, // Pakistan
        { "431", "Afghanistan Standard Time" }, // Afghanistan
        { "432", "Sri Lanka Standard Time" }, // Sri Lanka
        { "434", "Nepal Standard Time" }, // Nepal
        { "436", "India Standard Time" }, // Bhutan (Likely aligns with India)
        { "437", "India Standard Time" }, // India
        { "438", "India Standard Time" }, // India
        { "440", "Tokyo Standard Time" }, // Japan
        { "441", "West Asia Standard Time" }, // Tajikistan
        { "450", "Myanmar Standard Time" }, // Myanmar
        { "452", "SE Asia Standard Time" }, // Thailand
        { "454", "Singapore Standard Time" }, // Malaysia (Kuala Lumpur)
        { "455", "Singapore Standard Time" }, // Malaysia (Kuching)
        { "456", "Singapore Standard Time" }, // Singapore
        { "457", "SE Asia Standard Time" }, // Indonesia (Jakarta)
        { "460", "China Standard Time" }, // China (Beijing)
        { "461", "China Standard Time" }, // China (Beijing)
        { "466", "Taipei Standard Time" }, // Taiwan
        { "467", "China Standard Time" }, // Hong Kong
        { "470", "SE Asia Standard Time" }, // Philippines
        { "501", "AUS Eastern Standard Time" }, // Australia (NSW)
        { "502", "Cen. Australia Standard Time" }, // Australia (SA)
        { "503", "E. Australia Standard Time" }, // Australia (QLD)
        { "504", "W. Australia Standard Time" }, // Australia (WA)
        { "505", "AUS Eastern Standard Time" }, // Australia (VIC)
        { "506", "Tasmania Standard Time" }, // Australia (TAS)
        { "507", "AUS Central Standard Time" }, // Australia (NT)
        { "508", "AUS Eastern Standard Time" }, // Australia (ACT)
        { "510", "West Pacific Standard Time" }, // Guam
        { "515", "West Pacific Standard Time" }, // Palau
        { "520", "West Pacific Standard Time" }, // Nauru
        { "523", "West Pacific Standard Time" }, // Marshall Islands
        { "525", "West Pacific Standard Time" }, // Micronesia (Chuuk)
        { "530", "West Pacific Standard Time" }, // Kiribati (Tarawa)
        { "535", "West Pacific Standard Time" }, // Tuvalu
        { "536", "Central Pacific Standard Time" }, // Vanuatu
        { "537", "Central Pacific Standard Time" }, // New Caledonia
        { "539", "New Zealand Standard Time" }, // New Zealand (Auckland)
        { "540", "New Zealand Standard Time" }, // New Zealand (Auckland)
        { "541", "Samoa Standard Time" }, // Samoa
        { "542", "Tonga Standard Time" }, // Tonga
        { "543", "West Pacific Standard Time" }, // Tuvalu
        { "544", "Central Pacific Standard Time" }, // Wallis and Futuna
        { "545", "Fiji Standard Time" }, // Fiji
        { "546", "New Zealand Standard Time" }, // Niue (Likely aligns)
        { "547", "New Zealand Standard Time" }, // Cook Islands (Likely aligns)
        { "548", "Samoa Standard Time" }, // American Samoa
        { "549", "West Pacific Standard Time" }, // French Polynesia (Tahiti)
        { "550", "Central Pacific Standard Time" }, // Solomon Islands
        { "551", "West Pacific Standard Time" }, // Micronesia (Kosrae)
        { "552", "West Pacific Standard Time" }, // Micronesia (Pohnpei)
        { "553", "West Pacific Standard Time" }, // Wake Island (US territory)
        { "601", "W. Central Africa Standard Time" }, // Algeria
        { "602", "Egypt Standard Time" }, // Egypt
        { "603", "Libya Standard Time" }, // Libya
        { "604", "Morocco Standard Time" }, // Tunisia (Likely aligns)
        { "605", "Morocco Standard Time" }, // Morocco
        { "606", "W. Central Africa Standard Time" }, // Nigeria
        { "607", "Greenwich Standard Time" }, // Ghana
        { "608", "Greenwich Standard Time" }, // Côte d'Ivoire
        { "609", "Greenwich Standard Time" }, // Senegal
        { "610", "Greenwich Standard Time" }, // Liberia
        { "611", "Greenwich Standard Time" }, // Sierra Leone
        { "612", "Greenwich Standard Time" }, // Mali
        { "613", "W. Central Africa Standard Time" }, // Niger
        { "614", "Greenwich Standard Time" }, // Togo
        { "615", "W. Central Africa Standard Time" }, // Benin
        { "616", "Greenwich Standard Time" }, // Burkina Faso
        { "617", "Cape Verde Standard Time" }, // Cape Verde
        { "618", "Sao Tome Standard Time" }, // Sao Tome and Principe
        { "619", "W. Central Africa Standard Time" }, // Equatorial Guinea
        { "620", "W. Central Africa Standard Time" }, // Gabon
        { "621", "W. Central Africa Standard Time" }, // Congo (Brazzaville)
        { "622", "W. Central Africa Standard Time" }, // Congo (Kinshasa)
        { "623", "W. Central Africa Standard Time" }, // Angola
        { "624", "W. Central Africa Standard Time" }, // Cameroon
        { "625", "W. Central Africa Standard Time" }, // Central African Republic
        { "626", "Sudan Standard Time" }, // Sudan
        { "627", "E. Africa Standard Time" }, // Ethiopia
        { "628", "E. Africa Standard Time" }, // Kenya
        { "629", "E. Africa Standard Time" }, // Tanzania
        { "630", "E. Africa Standard Time" }, // Uganda
        { "631", "E. Africa Standard Time" }, // Burundi
        { "632", "E. Africa Standard Time" }, // Rwanda
        { "633", "Mauritius Standard Time" }, // Réunion
        { "634", "Mauritius Standard Time" }, // Mauritius
        { "635", "E. Africa Standard Time" }, // Comoros (Likely aligns)
        { "636", "E. Africa Standard Time" }, // Mayotte (Likely aligns)
        { "637", "Mauritius Standard Time" }, // Madagascar
        { "638", "E. Africa Standard Time" }, // Djibouti
        { "639", "E. Africa Standard Time" }, // Eritrea
        { "640", "E. Africa Standard Time" }, // Somalia
        { "641", "South Africa Standard Time" }, // South Africa
        { "642", "South Africa Standard Time" }, // Zimbabwe
        { "643", "South Africa Standard Time" }, // Zambia
        { "645", "South Africa Standard Time" }, // Mozambique
        { "646", "Namibia Standard Time" }, // Namibia
        { "647", "South Africa Standard Time" }, // Botswana
        { "648", "South Africa Standard Time" }, // Lesotho
        { "649", "South Africa Standard Time" }, // Swaziland
        { "650", "Morocco Standard Time" }, // Canary Islands (Spain)
        { "651", "Cape Verde Standard Time" }, // Cape Verde
        { "652", "Azores Standard Time" }, // Azores (Portugal)
        { "653", "Morocco Standard Time" }, // Madeira (Portugal)
        { "702", "Central America Standard Time" }, // Belize
        { "704", "Central America Standard Time" }, // Guatemala
        { "706", "Central America Standard Time" }, // El Salvador
        { "708", "Central America Standard Time" }, // Honduras
        { "710", "Central America Standard Time" }, // Nicaragua
        { "712", "SA Pacific Standard Time" }, // Costa Rica (Likely aligns with Pacific SA)
        { "714", "SA Pacific Standard Time" }, // Panama (Pacific side)
        { "716", "Central Standard Time (Mexico)" }, // Mexico (Central)
        { "724", "Central Standard Time (Mexico)" }, // Mexico (Central)
        { "734", "Central Standard Time (Mexico)" }, // Mexico (Central)
        { "748", "Central Standard Time (Mexico)" }, // Mexico (Central)
        { "750", "Central Standard Time (Mexico)" }, // Mexico (Central)
        { "760", "Central Standard Time (Mexico)" }, // Mexico (Central)
        { "766", "Central Standard Time (Mexico)" }, // Mexico (Central)
        { "804", "Pacific SA Standard Time" }, // Chile (Continental)
        { "806", "SA Western Standard Time" }, // Bolivia
        { "810", "SA Pacific Standard Time" }, // Peru
        { "812", "SA Pacific Standard Time" }, // Ecuador (Continental)
        { "814", "SA Pacific Standard Time" }, // Colombia
        { "820", "SA Western Standard Time" }, // Guyana
        { "822", "SA Western Standard Time" }, // Suriname
        { "826", "SA Eastern Standard Time" }, // French Guiana
        { "830", "E. South America Standard Time" }, // Brazil (Most Eastern parts)
        { "832", "Argentina Standard Time" }, // Argentina
        { "834", "Argentina Standard Time" }, // Uruguay (Similar to Argentina)
        { "838", "Paraguay Standard Time" }, // Paraguay
        { "850", "Venezuela Standard Time" }, // Venezuela
        { "852", "Atlantic Standard Time" }, // Antigua and Barbuda
        { "854", "Atlantic Standard Time" }, // Saint Kitts and Nevis
        { "856", "Atlantic Standard Time" }, // Dominica
        { "858", "Atlantic Standard Time" }, // Saint Lucia
        { "860", "Atlantic Standard Time" }, // Grenada
        { "862", "Atlantic Standard Time" }, // Barbados
        { "864", "Atlantic Standard Time" }, // Saint Vincent and the Grenadines
        { "868", "Atlantic Standard Time" }, // Trinidad and Tobago
        { "870", "Atlantic Standard Time" }, // Montserrat
        { "872", "Atlantic Standard Time" }, // Anguilla
        { "874", "Atlantic Standard Time" }, // Aruba
        { "876", "Atlantic Standard Time" }, // Curaçao
        { "878", "Atlantic Standard Time" }, // Bonaire
        { "901", "West Pacific Standard Time" }, // Guam
        { "909", "West Pacific Standard Time" }, // Wake Island (US)
        { "910", "West Pacific Standard Time" }, // Palau
        { "911", "West Pacific Standard Time" }, // Micronesia (Chuuk)
        { "912", "West Pacific Standard Time" }, // Micronesia (Kosrae)
        { "913", "West Pacific Standard Time" }, // Micronesia (Pohnpei)
        { "914", "West Pacific Standard Time" }, // Marshall Islands
        { "915", "West Pacific Standard Time" }, // Kiribati (Tarawa)
        { "916", "West Pacific Standard Time" }, // Nauru
        { "917", "West Pacific Standard Time" }, // Tuvalu
        { "918", "West Pacific Standard Time" }, // Tokelau (NZ)
        { "919", "West Pacific Standard Time" }, // Wallis and Futuna (FR)
        { "920", "Fiji Standard Time" }, // Fiji
        { "921", "New Zealand Standard Time" }, // Niue (NZ)
        { "922", "New Zealand Standard Time" }, // Cook Islands (NZ)
        { "923", "Samoa Standard Time" }, // American Samoa (US)
        { "925", "West Pacific Standard Time" }, // French Polynesia (Tahiti)
        { "926", "West Pacific Standard Time" }, // French Polynesia (Marquesas)
        { "927", "West Pacific Standard Time" }, // French Polynesia (Gambier)
        { "928", "West Pacific Standard Time" }, // Papua New Guinea
        { "929", "West Pacific Standard Time" }, // Micronesia (Truk - old name for Chuuk)
        { "930", "Central Pacific Standard Time" }, // Solomon Islands
        { "931", "Central Pacific Standard Time" }, // New Caledonia (FR)
        { "933", "New Zealand Standard Time" }, // New Zealand
        { "934", "Chatham Islands Standard Time" }, // Chatham Islands (NZ)
        { "935", "Samoa Standard Time" }, // Samoa
        { "936", "Tonga Standard Time" }, // Tonga
        { "937", "Line Islands Standard Time" }, // Kiribati (Kiritimati)
        { "939", "Central Pacific Standard Time" }, // Vanuatu
        { "940", "West Pacific Standard Time" }, // Palau
        { "941", "West Pacific Standard Time" }, // Tuvalu
        { "942", "West Pacific Standard Time" }, // Nauru
        { "943", "West Pacific Standard Time" }, // Kiribati (Tarawa)
        { "950", "West Asia Standard Time" }, // Afghanistan (Kabul)
    }.ToFrozenDictionary(StringComparer.Ordinal);


    public static readonly IReadOnlyDictionary<string, TimeZoneInfo> MobileCountyCodeToTimeZone = MobileCountyCodeToTimeZoneId.ToFrozenDictionary(
        kvp => kvp.Key,
        kvp => TimeZoneInfo.FindSystemTimeZoneById(kvp.Value),
        StringComparer.Ordinal);
}