define({ "api": [
  {
    "type": "Post",
    "url": "api/SuperMarketManage/AddNewWaiter",
    "title": "新增服务员",
    "description": "<p>新增服务员</p>",
    "name": "AddNewWaiter",
    "group": "SupermarketManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>AddNewWaiter</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "UserMobile",
            "description": "<p>or UserAccount  手机号 或 用户账号</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Type",
            "description": "<p>1-手机号 2-用户账号</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{UserAccount:用户账号,UserMoible:用户手机号,UserAvatar:用户头像,RegisterTime:注册时间}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SupermarketManageController.cs",
    "groupTitle": "SupermarketManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SuperMarketManage/AddNewWaiter"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SuperMarketManage/ChangeStatus",
    "title": "修改货架的状态",
    "description": "<p>查看货架商品</p>",
    "name": "ChangeStatus",
    "group": "SupermarketManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>ChangeStatus</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ShelvesAccount",
            "description": "<p>货架账号</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ActivationState",
            "description": "<p>货架状态 0-未激活 1-已激活</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>0-失败 1-成功</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SupermarketManageController.cs",
    "groupTitle": "SupermarketManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SuperMarketManage/ChangeStatus"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SuperMarketManage/ChangeWaiterStatus",
    "title": "更改服务员状态",
    "description": "<p>更改服务员状态</p>",
    "name": "ChangeWaiterStatus",
    "group": "SupermarketManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>ChangeWaiterStatus</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "UserAccount",
            "description": "<p>用户账号</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "UserType",
            "description": "<p>用户类型（5-会员 6-服务员）</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{0-失败 1-成功}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SupermarketManageController.cs",
    "groupTitle": "SupermarketManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SuperMarketManage/ChangeWaiterStatus"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SuperMarketManage/DisplayOrderInfo",
    "title": "获取订单列表",
    "description": "<p>获取订单列表</p>",
    "name": "DisplayOrderInfo",
    "group": "SupermarketManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>DisplayOrderInfo</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "DealStatus",
            "description": "<p>订单状态(1-未支付 5-已确认)</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{DealNumber:交易单号,ShelvesAccount:货架账号,CommodityName:商品名称,DealSum:商品数量,Univalent:单价,DealMoney:订单金额,UserAccount:下单用户,PaymentTime:下单时间,PayInstitution:支付方式,TradeTime:完成时间}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SupermarketManageController.cs",
    "groupTitle": "SupermarketManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SuperMarketManage/DisplayOrderInfo"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SuperMarketManage/OrderDetails",
    "title": "订单详情",
    "description": "<p>获取单个订单的详情</p>",
    "name": "OrderDetails",
    "group": "SupermarketManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>OrderDetails</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "DealNumber",
            "description": "<p>订单号</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{ShelvesAccount:货架账号,,DealSum:商品数量,Univalent:单价,DealMoney:订单金额,DealStatus:订单状态（0-购物车、1-未支付、2-未发货、3-已发货、4-已收货、5-已确认、6-退货）,ReceiptTime:确认时间,DeliveryTime:发货时间,ConfirmTime:完成时间,CommodityName:商品名称,WorkAddress:货架地址}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SupermarketManageController.cs",
    "groupTitle": "SupermarketManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SuperMarketManage/OrderDetails"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SuperMarketManage/ShowShelfInfo",
    "title": "货架管理首页",
    "description": "<p>货架管理首页</p>",
    "name": "ShowShelfInfo",
    "group": "SupermarketManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>ShowShelfInfo</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ActivationState",
            "description": "<p>货架状态 0-未激活（默认）1-已激活</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{UserAccount:用户账号,ShelvesAccount:货架账号,ShelvesType:货架类型,ActivationState:货架状态,DialMobile:拨号电话,WorkAddress:工作地址,MACAddress:MAC地址,LongitudeValue:经度,LatitudeValue:纬度,LoginNum:登录次数,LoginTime:登录时间,LoginIP:登录IP,LoginLastTime:上一次登录时间,LoginLastIP:上一次登录IP}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SupermarketManageController.cs",
    "groupTitle": "SupermarketManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SuperMarketManage/ShowShelfInfo"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SuperMarketManage/ViewProduct",
    "title": "查看货架商品",
    "description": "<p>查看货架商品</p>",
    "name": "ViewProduct",
    "group": "SupermarketManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>ViewProduct</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ShelvesAccount",
            "description": "<p>货架账号</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{CommodityNumber:七位商品码,BarCode:条形码,StockSum:库存}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SupermarketManageController.cs",
    "groupTitle": "SupermarketManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SuperMarketManage/ViewProduct"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SuperMarketManage/WaiterList",
    "title": "服务员列表",
    "description": "<p>服务员列表</p>",
    "name": "WaiterList",
    "group": "SupermarketManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>WaiterList</p>"
          },
          {
            "group": "Parameter",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>传默认值0</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{UserAccount:用户账号,UserMobile:用户电话,UserAvatar:用户头像,RegisterTime:注册时间}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SupermarketManageController.cs",
    "groupTitle": "SupermarketManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SuperMarketManage/WaiterList"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SystemMaintainManage/DeleteClassification",
    "title": "删除分类",
    "description": "<p>删除分类</p>",
    "name": "DeleteClassification",
    "group": "SystemMaintainManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>DeleteClassification</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "DATA",
            "description": "<p>{IndustryName:行业名称,ClassifyName:分类名称}</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{0-失败 1-成功}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SystemMaintainManageController.cs",
    "groupTitle": "SystemMaintainManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SystemMaintainManage/DeleteClassification"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SystemMaintainManage/EditClassification",
    "title": "编辑分类",
    "description": "<p>更改服务员状态</p>",
    "name": "EditClassification",
    "group": "SystemMaintainManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>EditClassification</p>"
          },
          {
            "group": "Parameter",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{IndustryName:行业名称,OldClassifyName:旧的分类名,NewClassifyName:新的分类名}</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{0-失败 1-成功}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SystemMaintainManageController.cs",
    "groupTitle": "SystemMaintainManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SystemMaintainManage/EditClassification"
      }
    ]
  },
  {
    "type": "Post",
    "url": "api/SystemMaintainManage/EnumIndustryList",
    "title": "显示行业目录",
    "description": "<p>显示行业目录</p>",
    "name": "EnumIndustryList",
    "group": "SystemMaintainManage",
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "SOURCE",
            "description": "<p>文件名</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "CREDENTIALS",
            "description": "<p>用户名或凭证，无凭证缺省填0</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "TERMINAL",
            "description": "<p>用户访问终端 0-PC，1-Android，2-iOS</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "INDEX",
            "description": "<p>数据包序列，缺省填写时间格式年月日时分秒：20160101123001</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "METHOD",
            "description": "<p>EnumIndustryList</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "DATA",
            "description": "<p>0</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Array",
            "optional": false,
            "field": "DATA",
            "description": "<p>{IndustryName:行业名称,ClassifyName:分类名称,ClassifyNum:分类数量一个行业对应多个分类，根据分类数量对应行业的分类）,EditTime:编辑日期}</p>"
          }
        ]
      }
    },
    "filename": "Controllers/SystemMaintainManageController.cs",
    "groupTitle": "SystemMaintainManage",
    "sampleRequest": [
      {
        "url": "http://120.78.49.234/OperationPlatformApi/api/SystemMaintainManage/EnumIndustryList"
      }
    ]
  }
] });
