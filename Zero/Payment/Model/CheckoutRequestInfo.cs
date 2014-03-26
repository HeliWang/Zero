using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Payment.Model
{
    public class CheckoutRequestInfo
    {
        // 必须，|旧名称|，限制

        /// <summary>
        /// API 的名称：SetExpressCheckout
        /// 必填；
        /// </summary>
        public string METHOD { get; set; }

        /// <summary>
        /// 一种时间戳 token，在 SetExpressCheckout 请求的返回值里
        /// 必填；20个字节
        /// </summary>
        public string TOKEN { get; set; }

        /// <summary>
        /// 客户选择通过 PayPal 付款后其浏览器将返回到的 URL。注意：PayPal 建议该参数的值为客户确认订单和付款或者结算协议的最终查看页面
        /// 必填；2048 个字节
        /// </summary>
        public string RETURNURL { get; set; }

        /// <summary>
        /// 客户不批准使用 PayPal 向您付款时将返回到的 URL。注意：PayPal 建议该参数的值为客户选择通过 PayPal 付款或签订结算协议的最初页面。
        /// 必填；无限制
        /// </summary>
        public string CANCELURL { get; set; }


        /// <summary>
        /// 客户需承担的交易总费用。如果运费和税金已知，请将它们包含在该值中；如果未知，则该值应为订单的当前小计。
        /// 如果交易包含一笔或多笔一次性购买，则该字段必须等于这些购买的合计。如果交易不包含一次性购买，则该字段可设置为 0。
        /// 必填；AMT(弃用)；任何币种的金额都不得超过 10,000美元。且不要包含币种代码。必须要有两位小数，小数分隔符为点号(.),还可以选择性地添加千位分隔符(,)
        /// </summary>
        public double PAYMENTREQUEST_n_AMT { get; set; }

        /// <summary>
        /// 从 PayPal 发送回调请求的 URL 地址。URL 开头必须是HTTPS,如果实在 sandbox 测试的话，可以以 HTTPS 或者HTTP 开头
        /// 未必；字符长度和限制：1024 个字节，只对 53.0 后的版本有效
        /// </summary>
        public string CALLBACK { get; set; }

        /// <summary>
        /// 表明商家是否需要买家在 PayPal 账户中的邮寄地址是已经被确认的地址。
        /// 对于数字商品，此项为必需。而且一定要设成 0。此项必须是下列其中之一：0 – 不需要；1 – 需要
        /// 看情况；提示：此项如果被设置将会覆盖账户信息中相应设置
        /// </summary>
        public string REQCONFIRMSHIPPING { get; set; }

        /// <summary>
        /// 决定是否在 PayPal 付款页面展示邮寄地址。对于数字商品，此项为必需，而且要设成 1
        /// 0：在 PayPal 付款页面显示；1：不论如何都不显示；2：如果在参数当中没有传递，PayPal 将从账户当中取得
        /// 看情况；1个单字节的数字
        /// </summary>
        public string NOSHIPPING { get; set; }

        /// <summary>
        /// 决 定 PayPal 在 付 款 页 面 展 示 的 邮 寄 地 址 ， 是 在SetExpressCheckout 中设定的，而不是在买家账户中设定的邮寄地址。如果是显示的买家账户中设定的邮寄地址，将不能被修改。 
        /// 0 – PayPal 付款页面不显示传递过来的邮寄地址；1 – PayPal 付款页面显示传递过来的邮寄地址
        /// 未必；1个单字节的数字
        /// </summary>
        public string ADDROVERRIDE { get; set; }

        /// <summary>
        /// PayPal 付款页面显示语言的设置。PayPal 支持下列所示的国家代码
        /// AU – Australia；AT – Austria；BE – Belgium；BR – Brazil；CA – Canada；CH – Switzerland；CN – China；DE – Germany；ES – Spain；
        /// GB - United Kingdom；FR – France；IT – Italy；NL – Netherlands；PL – Poland；PT – Portugal；US -- United States
        /// 未必；2 个字节的国家代码，默认：US，提示：付款页面的语言由很多因素决定。例如买家和卖家所在地，操作系统，浏览器，用户所用的 IP 地址等等。
        /// </summary>
        public string LOCALECODE { get; set; }

        /// <summary>
        /// 设置与该按钮/链接相关的付款页面的“自定义付款页面样式 ”。 该 值 对 应 于 用 来 自 定 义 付 款 页 面 的 HTML 变 量page_style。
        /// 该值与您在 PayPal 账户“我的 PayPal” 选 项卡“用户信息”子选项卡上添加或编辑页面样式时选择的“页面样式名称”相同
        /// 未必；30 个单字节字母字符
        /// </summary>
        public string PAGESTYLE { get; set; }

        /// <summary>
        /// 您希望在付款页面左上角显示的图片的 URL。该图片的最大尺寸为 750 像素宽、90 像素高。PayPal 建议您提供安全(https)服务器上存储的图片。
        /// 如果您没有指定图片，企业账户，则显示公司名称。高级账户则为商家的账户的 EMAIL 地址
        /// 未必；127 个单字节字母数字字符
        /// </summary>
        public string HDRIMG { get; set; }

        /// <summary>
        /// 设置付款页面标题周围的边框颜色。边框是指位于标题空间四周，粗细为 2 像素的方框，方框尺寸为 750 像素宽、90 像素高。默认情况下，颜色为黑色
        /// 未必；六字符 HTML 十六进制 ASCII 颜色代码
        /// </summary>
        public string HDRBORDERCOLOR { get; set; }

        /// <summary>
        /// 设置付款页面标题的背景色。默认为白色
        /// 未必；六字符 HTML 十六进制 ASCII 颜色代码
        /// </summary>
        public string HDRBACKCOLOR { get; set; }

        /// <summary>
        /// 为付款页面设置背景色。默认为白色
        /// 未必；六字符 HTML 十六进制 ASCII 颜色代码
        /// </summary>
        public string PAYFLOWCOLOR { get; set; }

        /// <summary>
        /// 结账流程的类型
        /// Sole：买家不需要创建一个 PayPal 账户来付款，这被称为 PayPal 可选账户
        /// Mark：买家付款时必须拥有一个 PayPal 账户
        /// 未必
        /// </summary>
        public string SOLUTIONTYPE { get; set; }

        /// <summary>
        /// PayPal 付款页面展示的类型
        /// Billing – 首选为非 PayPal 账户；Login – 首选为 PayPal 账户
        /// 未必
        /// </summary>
        public string LANDINGPAGE { get; set; }

        /// <summary>
        /// 渠道类型，Merchant：非竞拍卖家，eBayItem：eBay 竞拍
        /// 未必；六字符 HTML 十六进制 ASCII 颜色代码
        /// </summary>
        public string CHANNELTYPE { get; set; }

        /// <summary>
        /// Giropay 付款成功后重定向到买家页面的 URL
        /// 未必；提示：只有当您使用了 giropay 或者德国境内的银行转账业务，此项才有效
        /// </summary>
        public string GIROPAYSUCCESSURL { get; set; }

        /// <summary>
        /// Giropay 付款失败后重定向买家页面的 URL
        /// 未必；提示：只有当您使用了 giropay 或者德国境内的银行转账业务，此项才有效
        /// </summary>
        public string GIROPAYCANCELURL { get; set; }

        /// <summary>
        /// 银行转账业务成功后转向买家页面的 URL
        /// 未必；提示：只有当您使用了 giropay 或者德国境内的银行转账业务，此项才有效
        /// </summary>
        public string BANKTXNPENDINGURL { get; set; }

        /// <summary>
        /// 显示在 PayPal 付款页面的商家客户联系电话
        /// 未必；16 位的单字节字符
        /// </summary>
        public string CUSTOMERSERVICENUMBER { get; set; }

        /// <summary>
        /// 是否允许礼物信息工具窗口展示在 PayPal 付款页面，0 – 不允许；1 – 允许
        /// 未必
        /// </summary>
        public string GIFTMESSAGEENABLE { get; set; }

        /// <summary>
        /// 是否允许礼物收据工具窗口展示在 PayPal 付款页面，0 – 不允许；1 – 允许
        /// 未必
        /// </summary>
        public string GIFTRECEIPTENABLE { get; set; }

        /// <summary>
        /// 是否允许礼物包装工具窗口展示在 PayPal 付款页面，0 – 不允许；1 – 允许
        /// 未必；提示：如果您传递的参数为 1，但礼物包装费和礼物包装的名称没有传递的话，礼物包装名称将不会被显示，并且礼物包装费用将显示成 0.00
        /// </summary>
        public string GIFTWRAPENABLE { get; set; }

        /// <summary>
        /// 礼物包装名称，例如“Box with rIbbon”
        /// 未必；25 个单字节字符
        /// </summary>
        public string GIFTWRAPNAME { get; set; }

        /// <summary>
        /// 买家付给包装礼物的价格
        /// 未必；任何币种的金额都不得超过 10,000 美元。且不要包含币种代码。必须要有两位小数，小数分隔符为点号(.)，还可以选择性地添加千位分隔符（,）
        /// </summary>
        public string GIFTWRAPAMOUNT { get; set; }

        /// <summary>
        /// 是否允许买家在 PayPal 付款页面提供他们的 email 地址，以接收以后的促销或者特别事件的通知邮件：，0 – 不允许；1 – 允许
        /// 未必
        /// </summary>
        public string BUYEREMAILOPTINENABLE { get; set; }

        /// <summary>
        /// 在 PayPal 付款页面提供调查问题。如果提供了调查问题，则至少需要提供 2 个调查答案
        /// 未必；50 单字节字符
        /// </summary>
        public string SURVEYQUESTION { get; set; }

        /// <summary>
        /// 回调服务器所使用的立即更新 API 的版本。默认的是现行的版本
        /// 未必
        /// </summary>
        public string CALLBACKVERSION { get; set; }

        /// <summary>
        /// 是否允许调查功能：0 – 关闭调查功能，1 – 开通调查功能
        /// 未必
        /// </summary>
        public string SURVEYENABLE { get; set; }

        /// <summary>
        /// PayPal 付款页面调查问题的答案选项。只有当一个有效的调查问题存在时，这些答案才有效
        /// 未必
        /// </summary>
        public string L_SURVEYCHOICEn { get; set; }

        /// <summary>
        /// 收件人姓名。如果使用邮寄地址，这个参数为必需。最多可以指定 10 个交易，n 的值是 0 到 9。
        /// 未必；版本63.0之后，SHIPTONAME 已被弃用；32 单字节字符
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPTONAME { get; set; }

        /// <summary>
        /// 第一街道地址。如果使用邮寄地址，这个参数为必需。最多可以指定 10 个交易，n 的值是 0 到 9
        /// 未必；版本63.0之后，SHIPTOSTREET 已被弃用；32 单字节字符；100 单字节字符
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPTOSTREET { get; set; }

        /// <summary>
        /// 第二街道地址。最多可以指定 10 个交易，n 的值是 0 到 9
        /// 未必；版本63.0之后，SHIPTOSTREET2 已被弃用；100 单字节字符
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPTOSTREET2 { get; set; }

        /// <summary>
        /// 城市名。如果使用邮寄地址，这个参数为必需。最多可以指定 10 个交易，n 的值是 0 到 9
        /// 未必；版本63.0之后，SHIPTOCITY已被弃用；40单字节字符
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPTOCITY { get; set; }


        /// <summary>
        /// 州或省。如果使用邮寄地址，这个参数为必需。最多可以指定 10 个交易，n 的值是 0 到 9
        /// 未必；版本63.0之后，SHIPTOSTATE已被弃用；40单字节字符
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPTOSTATE { get; set; }

        /// <summary>
        /// 美国或者其他国家的邮政编码。如果使用邮寄地址，这个参数是必需的。最多可以指定 10 个交易，n 的值是 0 到 9
        /// 未必；版本63.0之后，SHIPTOZIP已被弃用；20单字节字符
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPTOZIP { get; set; }

        /// <summary>
        /// 国家代码。如果使用邮寄地址，这个参数是必需的。最多可以指定 10 个交易，n 的值是 0 到 9
        /// 未必；SHIPTOCOUNTRYCODE(弃用)；版本63.0之后，SHIPTOCOUNTRY已被弃用；2单字节字符
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPTOCOUNTRYCODE { get; set; }

        /// <summary>
        /// 电话号码。最多可以指定 10 个交易，n 的值是 0 到 9
        /// 必；版本63.0之后，SHIPTOPHONENUM已被弃用；20单字节字符
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPTOPHONENUM { get; set; }

        /// <summary>
        /// 订单所有物品的价格。对于数字商品，此项为必需。最多可以指定 10 个交易，n 的值是 0 到 9。除了数字商品，因为数字商品只支持单个物品付款
        /// 任何币种的金额都不得超过 10,000 美元。且不要包含币种代码。必须要有两位小数，小数分隔符为点号(.)，还可以选择性地添加千位分隔符(,)
        /// 未必；版本63.0之后，ITEMAMT已被弃用；20单字节字符，提 示 ： 如 果 指 定 了 L_PAYMENTREQUEST_n_AMTm ，PAYMENTREQUEST_n_ITEMAMT 是必需的
        /// </summary>
        public double PAYMENTREQUEST_n_ITEMAMT { get; set; }

        /// <summary>
        /// 订单的邮费总额。最多可以指定 10 个交易，n 的值是 0 到 9。如果给 PAYMENTREQUEST_n_SHIPPINGAMT 指定一个值，同时您也得给 PAYMENTREQUEST_n_ITEMAMT 指定一个值
        /// 未必；版本63.0之后，SHIPPINGAMT已被弃用；任何币种的金额都不得超过 10,000 美元....
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPPINGAMT { get; set; }

        /// <summary>
        /// 订单的邮寄保费总额。如果提供了保险，这个值必须是一个非负金额或者是 null。最多可以指定 10 个交易，n 的值是 0到 9
        /// 未必；版本63.0之后，SHIPPINGAMT已被弃用；任何币种的金额都不得超过 10,000 美元....
        /// </summary>
        public string PAYMENTREQUEST_n_INSURANCEAMT { get; set; }

        /// <summary>
        /// 订单的邮费折扣，指定一个负数。最多可以指定 10 个交易，n 的值是 0 到 9。
        /// 未必；SHIPDISCAMT(弃用)；版本63.0之后，SHIPPINGDISCAMT已被弃用；任何币种的金额都不得超过 10,000 美元....
        /// </summary>
        public string PAYMENTREQUEST_n_SHIPDISCAMT { get; set; }

        /// <summary>
        /// 表明在 PayPal 付款页面，保险是否展示给买家自行选择。最多可以指定 10 个交易，n 的值是 0 到 9
        /// true – 保险选项展示的是”YES”和保险金额如果为真，订单总的邮寄保费必须是个正数；false – 保险选项展示的是“NO”
        /// 未必；版本63.0之后，之后，INSURANCEOPTIONOFFERED已被弃用
        /// </summary>
        public string PAYMENTREQUEST_n_INSURANCEOPTIONOFFERED { get; set; }

        /// <summary>
        /// 订单处理费用的总额。最多可以指定 10 个交易，n 的值是 0到 9
        /// 提示：如果指定了 PAYMENTREQUEST_n_HANDLINGAMT，PAYMENTREQUEST_n_ITEMAMT 是必须
        /// 未必；版本63.0之后，HANDLINGAMT已被弃用；任何币种的金额都不得超过 10,000 美元....
        /// </summary>
        public string PAYMENTREQUEST_n_HANDLINGAMT { get; set; }

        /// <summary>
        /// 订单中所有物品税费的总和。最多可以指定 10 个交易，n 的值是 0 到 9。除了数字商品，因为数字商品只支持单个物品付款
        /// 提示：如果您设定了 L_PAYMENTREQUEST_n_TAXAMTm，则PAYMENTREQUEST_n_TAXAMT 是必须的
        /// 未必；版本63.0之后，TAXAMT已被弃用；任何币种的金额都不得超过 10,000 美元....
        /// </summary>
        public string PAYMENTREQUEST_n_TAXAMT { get; set; }

        /// <summary>
        /// 商户的唯一标识码。对于并行支付，此项为必需。而且必须包含 Payer Id 或者商户的邮箱地址。最多可以指定 10 笔付款，n 的值是 0 到 9
        /// 未必；127 单字节字母字符组合
        /// </summary>
        public string PAYMENTREQUEST_n_SELLERPAYPALACCOUNTID { get; set; }

        /// <summary>
        /// 覆盖您本地的容许 PayPal 可以处理回调请求和回复的超时时间。可以接受的时间范围是 1 到 6 秒。如果您指定的时间超过了 6 秒，PayPal 将使用默认时间 3 秒
        /// 未必；1 到 6 的整数
        /// </summary>
        public string CALLBACKTIMEOUT { get; set; }

        /// <summary>
        /// 允许买方在 PayPal 结账页面上输入了一条文本信息给给商家 。 这 条 文 本 信 息 将 在 GetExpressCheckoutDetails 和DoExpressCheckoutPayment 返回信息中返回。
        /// 允许下列的值：0 – 不允许；1 – 允许
        /// 未必；只对 53.0 后的版本有效
        /// </summary>
        public string ALLOWNOTE { get; set; }

        ///// <summary>
        ///// 转账后，客户将被重定向到商家网站的 URL
        ///// 提示：当您在使用 giropay 或者德国境内的银行转账业务之后，才有效
        ///// 未必
        ///// </summary>
        //public string BANKTXNPENDINGURL { get; set; }

        /// <summary>
        /// PayPal 结账页面显示的商户的标签，该值将会覆盖用户在PayPal 账户里设置的企业名称
        /// 未必；127 位的字符和数字的组合
        /// </summary>
        public string BRANDNAME { get; set; }

        /// <summary>
        /// “PayPal 支持的交易币种”中所列币种之一的三字符币种代码。默认值：USD
        /// 未必；CURRENCYCODE(弃用)
        /// </summary>
        public string PAYMENTREQUEST_n_CURRENCYCODE { get; set; }

        /// <summary>
        /// 整个订单的预计最大总金额，包括运费和税金。如果交易不包含一次性购买，则该字段可忽略。对于循环付款，您应该传递预计交易金额的平均值（默认25.00）。PayPal 利用这个值去验证买家的资金源
        /// 未必；任何币种的金额都不得超过 10,000 美元....
        /// </summary>
        public double MAXAMT { get; set; }

        /// <summary>
        ///希望获取付款的方式，如果交易不包含一次性购买，则该字段可忽略
        /// Sale 表示这是您正进行收款的最终销售
        /// Authorization 表示该付款是通过“PayPal 授权和捕获”结算的基本授权
        /// Order 表示该付款是通过“PayPal 授权和捕获”结算的订单授权
        /// 注意：不能先在 SetExpressCheckout 请求中将该值设置为 Sale，然后在最后的 API DoExpressCheckoutPayment 请求中将该值更改为 Authorization 或 Order。如果在 SetExpressCheckout 中将该值设置为 Authorization 或 Order ， 则 可 在DoExpressCheckoutPayment 中将该值设置为 Sale 或相同值（Authorization 或 Order）
        /// 未必；PAYMENTACTION（弃用）；最多 13 个单字节字母字符
        /// </summary>
        public string PAYMENTREQUEST_n_PAYMENTACTION { get; set; }

        /// <summary>
        /// 交易类型。可以指定的值为 InstantPaymentOnly。最多可以指定 10 笔付款，n 的值是 0 到 9
        /// 未必；版本63.0之后，ALLOWEDPAYMENTMETHOD已被弃用
        /// </summary>
        public string PAYMENTREQUEST_n_ALLOWEDPAYMENTMETHOD { get; set; }

        /// <summary>
        /// 结账时输入的买家电子邮件。PayPal 使用该值预填 PayPal 登录页面的 PayPal 会员注册部分
        /// 未必；127 个单字节字母数字字符
        /// </summary>
        public string EMAIL { get; set; }

        /// <summary>
        /// 客户所购物品的描述。最多可以指定 10 个交易，n 的值是 0到 9；数字商品除外，数字商品只支持单笔交易
        /// 提示：只有当此交易包括购买时，该指定的值才有效。对于一个循环付款，如果您设定了一个付款协议而不是立即付款的话。，该字段将被忽略。
        /// 未必；版本63.0之后，DESC已被弃用；127 个单字节字母数字字符
        /// </summary>
        public string PAYMENTREQUEST_n_DESC { get; set; }

        /// <summary>
        /// 用户可以根据自己的需求自定义的域。最多可以给 10 笔付款指定 10 个自定义域，n 的值是 0 到 9。
        /// 提示：只有当此交易包括购买时，该指定的值才有效。对于一个循环付款，如果您设定了一个付款协议而不是立即付款的话。，该字段将被忽略
        /// 未必；版本63.0之后，CUSTOM已被弃用；256 个单字节字母数字字符
        /// </summary>
        public string PAYMENTREQUEST_n_CUSTOM { get; set; }

        /// <summary>
        /// 您 自 己 的 唯 一 账 单 号 或 跟 踪 号 。 PayPal 在DoExpressCheckoutPayment 响应中将该值返回给您。如果交易不包含一次性购买，则该字段可忽略
        /// 未必；INVNUM(弃用)；127 个单字节字母数字字符
        /// </summary>
        public string PAYMENTREQUEST_n_INVNUM { get; set; }

        /// <summary>
        /// 您用来接收有关该交易的即时付款通知(IPN)的 URL。如果您在request 中没有指定该值，则使用账户中指定的 URL。最多可以给 10 笔付款指定 10 个 NOTIFYURL，n 的值是 0 到 9；数字商品除外，数字商品只支持单个物品交易
        /// 重要提示：这个 NOTIFYURL 只针对 DoExpressCheckoutPayment如果在 SetExpressCheckout 或 GetExpressCheckoutDetails 设定了该值，将被忽略
        /// 未必；版本63.0之后，CUSTOM已被弃用；2,048 个单字节字母数字字符
        /// </summary>
        public string PAYMENTREQUEST_n_NOTIFYURL { get; set; }

        /// <summary>
        /// 付款的唯一交易号。最多可以指定 10 笔付款的交易号，n 的值是 0 到 9
        /// 提示：该值只有在 DoExpressCheckout 交易成功返回之后才会创建
        /// 未必；版本63.0之后，TRANSACTIONID已被弃用
        /// </summary>
        public string PAYMENTREQUEST_n_TRANSACTIONID { get; set; }

        /// <summary>
        /// 特定付款请求的唯一标识符，对于并行支付来说是必须的。最多可以指定 10 笔付款，n 的值是 0 到 9
        /// 未必；版本63.0之后，CUSTOM已被弃用；最多 127 个单字节字符
        /// </summary>
        public string AYMENTREQUEST_n_PAYMENTREQUESTID { get; set; }



        /// <summary>
        /// 物品名称。如果 L_PAYMENTREQUEST_n_ITEMCATEGORYm 被指定，该值则必须被设定。最多可以指定 10 笔付款，n 的值是0 到 9。m 为该付款列表里指定的值
        /// 数字商品除外，数字商品只支持单个物品交易。该 参 数 必 须 从 0 开始按照顺序被指定（例如：L_PAYMENTREQUEST_n_NAME0,L_PAYMENTREQUEST_n_NAME1…）
        /// 未必；版本63.0之后，L_NAMEn已被弃用；127 个单字节字符
        /// </summary>
        public List<string> L_PAYMENTREQUEST_n_NAMEm { get; set; }

        /// <summary>
        /// 物品描述。最多可以指定 10 笔付款，n 的值是 0 到 9。m 为该付款列表里指定的值
        /// 数字商品除外，数字商品只支持单个物品交易。该参数必须从 0 开始按照顺序被指定（例如：L_PAYMENTREQUEST_n_DESC0,L_PAYMENTREQUEST_n_DESC1)。
        /// 未必；版本63.0之后，L_DESCn已被弃用；127 个单字节字符
        /// </summary>
        public List<string> L_PAYMENTREQUEST_n_DESCm { get; set; }

        /// <summary>
        /// 物品价格。如果 L_PAYMENTREQUEST_n_ITEMCATEGORYm 被指定，该值则必须被设定。最多可以指定 10 笔付款，n 的值是0 到 9。m 为该付款列表里指定的值
        /// 数字商品除外，数字商品只支持单个物品交易。该 参 数 必 须 从 0 开始按照顺序被指定（例如：L_PAYMENTREQUEST_n_AMT0,L_PAYMENTREQUEST_n_AMT1)
        /// 提 示 ： 如 果 您 设 定 了 L_PAYMENTREQUEST_n_AMTm ， 则PAYMENTREQUEST_n_ITEMAMT 必须被设定
        /// 未必；版本63.0之后，L_AMTn已被弃用；任何币种的金额都不得超过 10,000 美元....
        /// </summary>
        public List<string> L_PAYMENTREQUEST_n_AMTm { get; set; }

        /// <summary>
        /// 物品号。最多可以指定 10 笔付款，n 的值是 0 到 9。m 为该付款列表里指定的值
        /// 该 参 数 必 须 从 0 开始按照顺序被指定（例如：L_PAYMENTREQUEST_n_NUMBER0,L_PAYMENTREQUEST_n_NUMBER1)
        /// 未必；版本63.0之后，L_NUMBERn已被弃用；127 个单字节字符
        /// </summary>
        public List<string> L_PAYMENTREQUEST_n_NUMBERm { get; set; }

        /// <summary>
        /// 物品数量。如果 L_PAYMENTREQUEST_n_ITEMCATEGORYm 被指定，该值则必须被设定
        /// 如果是数字商品，则设成（L_PAYMENTREQUEST_n_ITEMCATEGORYm = Digital）。最多可以指定 10 笔付款，n 的值是 0 到 9。m 为该付款列表里指定的值。但是数字商品除外，因为数字商品支持单个物品交易。m 必 须 从 0 开始按照顺序被指定（例如：L_PAYMENTREQUEST_n_QTY0,L_PAYMENTREQUEST_n_QTY1)
        /// 未必；版本63.0之后，L_QTYn已被弃用；任何正整数
        /// </summary>
        public List<string> L_PAYMENTREQUEST_n_QTYm { get; set; }

        /// <summary>
        /// 物品营业税。最多可以指定 10 笔付款，n 的值是 0 到 9。m为该付款列表里指定的值
        /// 但是数字商品除外，因为数字商品支持单个物品交易。m 必 须 从 0 开始按照顺序被指定（例如：L_PAYMENTREQUEST_n_TAXAMT0 ，L_PAYMENTREQUEST_n_TAXAMT1)
        /// 未必；版本63.0之后，L_AMTn已被弃用；任何币种的金额都不得超过 10,000 美元....
        /// </summary>
        public List<string> L_PAYMENTREQUEST_n_TAXAMTm { get; set; }

        /// <summary>
        /// 物品重量。您可以将此数据直接传给运货人，而无需进行额外的数据库查询。最多可以指定 10 笔付款，n 的值是 0 到 9。m 为该付款列表里指定的值
        /// 未必；版本63.0之后，L_ITEMWEIGHTVALUEn已被弃用
        /// </summary>
        public List<string> L_PAYMENTREQUEST_n_ITEMWEIGHTVALUEm { get; set; }

        /// <summary>
        /// 物品重量。您可以将此数据直接传给运货人，而无需进行额外的数据库查询。最多可以指定 10 笔付款，n 的值是 0 到 9。m 为该付款列表里指定的值
        /// 未必；版本63.0之后，L_ITEMWEIGHTUNITn已被弃用
        /// </summary>
        public List<string> L_PAYMENTREQUEST_n_ITEMWEIGHTUNITm { get; set; }


    }
}
