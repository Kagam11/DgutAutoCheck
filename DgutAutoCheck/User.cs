using System.Runtime.CompilerServices;

namespace DgutAutoCheck
{
    /// <summary>
    /// 需打卡用户
    /// </summary>
    internal class User
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string? Password { get; set; }
    }

    // TODO: 哪天给他改成动态生成的类，防止每次增删数据都要重新硬编码
    #region 由json自动生成的类
#pragma warning disable IDE1006 // 别烦
#pragma warning disable CS8618

    #region 登录相关
    /// <summary>
    /// 获取登陆页面时获取的json
    /// </summary>
    public class LoginRespond
    {
        public LoginUrlData data { get; set; }
    }
    /// <summary>
    /// 获取登陆页面时获取json里面的数据
    /// </summary>
    public class LoginUrlData
    {
        public string url { get; set; }
    }

    #endregion

    #region 打卡相关
    /// <summary>
    /// 打卡时上传的信息主体
    /// </summary>
    public class UploadingDataBody
    {

        public UploadingDataBody(UserDataLast userDataLast, CustomProperty custom)
        {
            // 每天都要重写的四样
            body_temperature = custom.body_temperature.ToString();
            health_situation = custom.health_situation;
            is_in_school = custom.is_in_school;
            now_detail_address_name = custom.now_detail_address_name;
            now_detail_address = now_detail_address_name!.Split("/").ToList();

            submit_time = userDataLast.submit_time;
            name = userDataLast.name;
            faculty_name = userDataLast.faculty_name;
            class_name = userDataLast.class_name;
            username = userDataLast.username;
            card_number = userDataLast.card_number;
            identity_type = userDataLast.identity_type;
            remark = userDataLast.remark;
            tel = userDataLast.tel;
            connect_person = userDataLast.connect_person;
            connect_tel = userDataLast.connect_tel;
            family_address_detail = userDataLast.family_address_detail;
            current_country = userDataLast.current_country;
            current_province = userDataLast.current_province;
            current_city = userDataLast.current_city;
            current_district = userDataLast.current_district;
            latest_acid_test = userDataLast.latest_acid_test;
            current_in_city = userDataLast.current_in_city;
            huji_region = userDataLast.huji_region;
            family_region = userDataLast.family_region;
            jiguan_region = userDataLast.jiguan_region;
            current_region = userDataLast.current_region;
            huji_region_name = userDataLast.huji_region_name;
            family_region_name = userDataLast.family_region_name;
            jiguan_region_name = userDataLast.jiguan_region_name;
            card_type = userDataLast.card_type;
            campus = userDataLast.campus;
            have_gone_important_area = userDataLast.have_gone_important_area;
            have_contact_hubei_people = userDataLast.have_contact_hubei_people;
            have_contact_illness_people = userDataLast.have_contact_illness_people;
            have_isolation_in_dg = userDataLast.have_isolation_in_dg;
            is_in_dg = userDataLast.is_in_dg;
            is_new_in_dg = userDataLast.is_new_in_dg;
            have_go_out = userDataLast.have_go_out;
            is_specific_people = userDataLast.is_specific_people;
            health_code_status = userDataLast.health_code_status;
            in_controllerd_area = userDataLast.in_controllerd_area;
            completed_vaccination = userDataLast.completed_vaccination;
            have_stay_area = userDataLast.have_stay_area;
            family_situation = userDataLast.family_situation;
            gps_country = userDataLast.gps_country;
            gps_province = userDataLast.gps_province;
            gps_city = userDataLast.gps_city;
            gps_district = userDataLast.gps_district;
            gps_country_name = userDataLast.gps_country_name;
            gps_province_name = userDataLast.gps_province_name;
            gps_city_name = userDataLast.gps_city_name;
            gps_district_name = userDataLast.gps_district_name;
            gps_address_name = userDataLast.gps_address_name;
            now_in_area_level = userDataLast.now_in_area_level;
        }

        public string? now_detail_address_name { get; set; }
        public List<string> now_detail_address { get; set; }
        public string? submit_time { get; set; }
        public string? name { get; set; }
        public string? faculty_name { get; set; }
        public string? class_name { get; set; }
        public string? username { get; set; }
        public string? card_number { get; set; }
        public int? identity_type { get; set; }
        public string? remark { get; set; }
        public string? tel { get; set; }
        public string? body_temperature { get; set; }
        public string? connect_person { get; set; }
        public string? connect_tel { get; set; }
        public string? family_address_detail { get; set; }
        public string? current_country { get; set; }
        public string? current_province { get; set; }
        public string? current_city { get; set; }
        public string? current_district { get; set; }
        public string? latest_acid_test { get; set; }
        public int? now_in_area_level { get; set; }
        public int? current_in_city { get; set; }
        public List<string?> huji_region { get; set; }
        public List<string?> family_region { get; set; }
        public List<string?> jiguan_region { get; set; }
        public List<string?> current_region { get; set; }
        public string? huji_region_name { get; set; }
        public string? family_region_name { get; set; }
        public string? jiguan_region_name { get; set; }
        public string? card_type { get; set; }
        public int? campus { get; set; }
        public int? health_situation { get; set; }
        public int? have_gone_important_area { get; set; }
        public int? have_contact_hubei_people { get; set; }
        public int? have_contact_illness_people { get; set; }
        public int? have_isolation_in_dg { get; set; }
        public int? is_in_dg { get; set; }
        public int? is_new_in_dg { get; set; }
        public int? have_go_out { get; set; }
        public int? is_specific_people { get; set; }
        public int? health_code_status { get; set; }
        public int? in_controllerd_area { get; set; }
        public int? completed_vaccination { get; set; }
        public int? is_in_school { get; set; }
        public int? have_stay_area { get; set; }
        public List<int?> family_situation { get; set; }
        public string? gps_country { get; set; }
        public string? gps_province { get; set; }
        public string? gps_city { get; set; }
        public string? gps_district { get; set; }
        public string? gps_country_name { get; set; }
        public string? gps_province_name { get; set; }
        public string? gps_city_name { get; set; }
        public string? gps_district_name { get; set; }
        public string? gps_address_name { get; set; }
    }
    /// <summary>
    /// 用于生成打卡时上传的json
    /// </summary>
    public class UploadingData
    {
        public UploadingDataBody data { get; set; }
    }
    /// <summary>
    /// 生成获取Bearer的json
    /// </summary>
    public class BearerRequest
    {
        public string token { get; set; }
        public string state { get; set; }
    }
    /// <summary>
    /// 获取bearer的返回值
    /// </summary>
    public class BearerResponse
    {
        public string access_token { get; set; }
    }
    /// <summary>
    /// 打卡结果
    /// </summary>
    public class CheckResponse
    {
        public string message { get; set; }
    }
    #endregion

    #region 上次打卡信息相关，杂七杂八的类统一添加Last后缀
    /// <summary>
    /// 上次打卡信息
    /// </summary>
    public class LastData
    {
        public bool hide_submit { get; set; }
        public bool show_need_know { get; set; }
        public bool hide_reset { get; set; }
        /// <summary>
        /// 还能撤回提交的次数
        /// </summary>
        public int can_reset_times { get; set; }
        /// <summary>
        /// 已打卡x天的信息，撤回过就会显示重新提交
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 能否出入校园
        /// </summary>
        public string school_perms { get; set; }
        public UserDataLast user_data { get; set; }
    }
    public class AllYmjzResultLast
    {
        public object aefi { get; set; }
        public string age { get; set; }
        public string dueinoculationdate { get; set; }
        public string evaluation { get; set; }
        public object gendercode { get; set; }
        public string gendername { get; set; }
        public string healthecode { get; set; }
        public string idcardno { get; set; }
        public string inoculationdate { get; set; }
        public object inoculationinstitutioncode { get; set; }
        public string inoculationinstitutionname { get; set; }
        public object inoculationplace { get; set; }
        public string inoculationtypecode { get; set; }
        public string inoculationtypename { get; set; }
        public string inoculatorname { get; set; }
        public object inoculatorstaffno { get; set; }
        public string name { get; set; }
        public string needletimes { get; set; }
        public string organid { get; set; }
        public object partcode { get; set; }
        public string partname { get; set; }
        public object piats { get; set; }
        public string vaccinebatchnumber { get; set; }
        public string vaccinecode { get; set; }
        public object vaccinemanufacturercode { get; set; }
        public string vaccinemanufacturername { get; set; }
        public string vaccinename { get; set; }
        public string validitydate { get; set; }
    }
    public class OriginAcidTestFromApiLast
    {
        public object CBXZ { get; set; }
        public string WYBS { get; set; }
        public object RYLY { get; set; }
        public string SFSC { get; set; }
        public string CYJGMC { get; set; }
        public object XXDWMC { get; set; }
        public string CYJGZLDXZQH { get; set; }
        public string CYRQ { get; set; }
        public string GJ { get; set; }
        public DateTime GXSJ { get; set; }
        public string JCJG { get; set; }
        public string ZJLX { get; set; }
        public string ZJHM { get; set; }
        public string JCJGTBSJ { get; set; }
        public string JSLX { get; set; }
        public string JCJG1 { get; set; }
        public object HJD { get; set; }
        public string JCRQ { get; set; }
        public string XM { get; set; }
        public string JCXM { get; set; }
        public object CBLX { get; set; }
        public object JZD { get; set; }
        public string SJHM { get; set; }
        public string CYDD { get; set; }
        public string SF14TNJWRJRY { get; set; }
        public object CBD { get; set; }
        public string BBLX { get; set; }
        public object RYSF { get; set; }
        public string NL { get; set; }
        public string XB { get; set; }
    }
    public class UserDataLast
    {
        public bool is_en { get; set; }
        public int? is_important_area_people { get; set; }
        public string? created_time { get; set; }
        public string? username { get; set; }
        public string? faculty_id { get; set; }
        public string? faculty_name { get; set; }
        public string? class_id { get; set; }
        public string? class_name { get; set; }
        public string? grade_name { get; set; }
        public string? last_submit_time { get; set; }
        public string? submit_time { get; set; }
        public string? name { get; set; }
        public int? identity_type { get; set; }
        public string? off_campus_person_type { get; set; }
        public int? reset_times { get; set; }
        public int? submit_times { get; set; }
        public bool is_reset_submit { get; set; }
        public string? card_type { get; set; }
        public string? card_number { get; set; }
        public int? campus { get; set; }
        public List<string?> jiguan_region { get; set; }
        public string? jiguan_district { get; set; }
        public List<string?> huji_region { get; set; }
        public string? huji_district { get; set; }
        public List<string?> family_region { get; set; }
        public string? family_address_detail { get; set; }
        public string? tel { get; set; }
        public string? connect_person { get; set; }
        public string? connect_tel { get; set; }
        public int? health_situation { get; set; }
        public int? have_gone_important_area { get; set; }
        public int? have_contact_hubei_people { get; set; }
        public int? have_contact_illness_people { get; set; }
        public int? have_isolation_in_dg { get; set; }
        public int? is_in_dg { get; set; }
        public int? have_go_out { get; set; }
        public int? is_specific_people { get; set; }
        public List<int?> family_situation { get; set; }
        public int? have_stay_area { get; set; }
        public string? remark { get; set; }
        public double? body_temperature { get; set; }
        public int? health_code_status { get; set; }
        public int? in_controllerd_area { get; set; }
        public int? completed_vaccination { get; set; }
        public int? is_in_school { get; set; }
        public object holiday_go_out { get; set; }
        public int? now_in_area_level { get; set; }
        public object school_connect_person { get; set; }
        public object school_connect_tel { get; set; }
        public object have_diagnosis { get; set; }
        public object diagnosis_result { get; set; }
        public object processing_method { get; set; }
        public object important_area { get; set; }
        public object leave_important_area_time { get; set; }
        public object last_time_contact_hubei_people { get; set; }
        public object last_time_contact_illness_people { get; set; }
        public object end_isolation_time { get; set; }
        public int? current_in_city { get; set; }
        public int? is_new_in_dg { get; set; }
        public object plan_back_dg_time { get; set; }
        public object back_dg_transportation { get; set; }
        public object plan_details { get; set; }
        public object finally_back_time { get; set; }
        public object finally_back_transportation { get; set; }
        public object finally_plan_details { get; set; }
        public object recent_travel_situation { get; set; }
        public string? latest_acid_test { get; set; }
        public object acid_test_results { get; set; }
        public object two_week_itinerary { get; set; }
        public object focus_area { get; set; }
        public object first_vaccination_date { get; set; }
        public object plan_vaccination_date { get; set; }
        public object holiday_travel_situation { get; set; }
        public string? current_country { get; set; }
        public string? current_province { get; set; }
        public string? current_city { get; set; }
        public string? current_district { get; set; }
        public List<string?> current_region { get; set; }
        public string? gps_country_name { get; set; }
        public string? gps_province_name { get; set; }
        public string? gps_city_name { get; set; }
        public string? gps_district_name { get; set; }
        public string? gps_address_name { get; set; }
        public string? gps_country { get; set; }
        public string? gps_province { get; set; }
        public string? gps_city { get; set; }
        public string? gps_district { get; set; }
        public string? jiguan_region_name { get; set; }
        public string? huji_region_name { get; set; }
        public string? family_region_name { get; set; }
        public string? current_region_name { get; set; }
        public bool request_health_code_api { get; set; }
        public List<OriginAcidTestFromApiLast> origin_acid_test_from_api { get; set; }
        public bool request_acid_test_api { get; set; }
        public bool request_ymjz_api { get; set; }
        public string? ymjz { get; set; }
        public List<AllYmjzResultLast> all_ymjz_result { get; set; }
        public List<string?> change_comment { get; set; }
        public int? is_change { get; set; }
    }
    #endregion

#pragma warning restore CS8618
#pragma warning restore IDE1006
    #endregion

    #region 异常处理类
    /// <summary>
    /// 打卡时错误
    /// </summary>
    public class CheckException : Exception
    {
        public CheckException(string? message) : base(message) { }
    }
    /// <summary>
    /// 登录时错误
    /// </summary>
    public class LoginException : Exception
    {
        public LoginException(string? message) : base(message) { }
    }
    #endregion
}
