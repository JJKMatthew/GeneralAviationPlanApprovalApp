-- 创建数据库
CREATE DATABASE GAPA;
GO

USE GAPA;
GO

-- 1. 用户表(用户ID、用户名、密码、用户类型、创建时间)
CREATE TABLE [User_Info] (
    UserID SMALLINT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    UserType NVARCHAR(20) NOT NULL,
    CreatedTime DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT CHK_UserType 
        CHECK (UserType IN ('企业', '管制人员'))
);
GO

-- 2. 企业信息表（企业ID、用户ID、企业名称、经营许可证号、联系电话、创建时间）
CREATE TABLE Enterprise_Info (
    EnterpriseID INT IDENTITY(1,1) PRIMARY KEY,
    UserID SMALLINT NOT NULL FOREIGN KEY REFERENCES [User_Info](UserID),
    CompanyName NVARCHAR(80) NOT NULL,
    LicenseCode NVARCHAR(60) UNIQUE NOT NULL,
    ContactPhone NVARCHAR(50),
    CreatedTime DATETIME DEFAULT GETDATE()
);
GO

-- 3. 飞行器信息表（飞行器ID、企业ID、注册号、机型、最大载重、状态、创建时间）
CREATE TABLE Aircraft_Info (
    AircraftID INT IDENTITY(1,1) PRIMARY KEY,
    EnterpriseID INT NOT NULL FOREIGN KEY REFERENCES Enterprise_Info(EnterpriseID),
    RegNumber NVARCHAR(20) UNIQUE NOT NULL,
    ModelType NVARCHAR(50) NOT NULL,
    MaxLoad DECIMAL(10,2) NULL,
    Status NVARCHAR(20) DEFAULT '可用',
    CreatedTime DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT CHK_AircraftStatus 
        CHECK (Status IN ('可用', '维修中', '停用'))
);
GO

-- 4. 飞行员信息表（飞行员ID、企业ID、姓名、执照编号、联系电话、状态、创建时间）
CREATE TABLE Pilot_Info (
    PilotID INT IDENTITY(1,1) PRIMARY KEY,
    EnterpriseID INT NOT NULL FOREIGN KEY REFERENCES Enterprise_Info(EnterpriseID),
    PilotName NVARCHAR(50) NOT NULL,
    LicenseNo NVARCHAR(30) UNIQUE NOT NULL,
    Phone NVARCHAR(20),
    Status NVARCHAR(20) DEFAULT '在职',
    CreatedTime DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT CHK_PilotStatus 
        CHECK (Status IN ('在职', '休假', '停飞'))
);
GO

-- 5. 飞行计划表（计划ID、企业ID、飞行器ID、飞行员ID、航线信息、开始时间、结束时间、状态、提交时间）
CREATE TABLE Flight_Plan (
    PlanID INT IDENTITY(1,1) PRIMARY KEY,
    EnterpriseID INT NOT NULL FOREIGN KEY REFERENCES Enterprise_Info(EnterpriseID),
    AircraftID INT NOT NULL FOREIGN KEY REFERENCES Aircraft_Info(AircraftID),
    PilotID INT NOT NULL FOREIGN KEY REFERENCES Pilot_Info(PilotID),
    RouteDescription NVARCHAR(MAX) NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    Status NVARCHAR(20) DEFAULT '草稿',
    SubmitTime DATETIME NULL,
    
    CONSTRAINT CHK_FlightPlanStatus 
        CHECK (Status IN ('草稿', '已提交', '审批中', '已批准', '已拒绝','已超期', '已执行', '已取消')),
    CONSTRAINT CHK_TimeRange 
        CHECK (EndTime > StartTime)
);
GO

-- 6. 审批记录表（记录ID、计划ID、审查人ID、结果、审批意见、审批时间）
CREATE TABLE Approval_Log (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    PlanID INT NOT NULL FOREIGN KEY REFERENCES Flight_Plan(PlanID),
    ReviewerID SMALLINT NOT NULL FOREIGN KEY REFERENCES [User_Info](UserID),
    Result NVARCHAR(20) NOT NULL,
    Comments NVARCHAR(MAX) NULL,
    ApprovalTime DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT CHK_ApprovalResult 
        CHECK (Result IN ('通过', '拒绝', '退回修改'))
);
GO

-- 7. 告警通知表（告警ID、计划ID、审查人ID、告警类型、内容、是否已读（是否告警0为否）、创建时间）
CREATE TABLE Alert_Notification (
    AlertID INT IDENTITY(1,1) PRIMARY KEY,
    PlanID INT NOT NULL FOREIGN KEY REFERENCES Flight_Plan(PlanID),
    ReviewerID SMALLINT NOT NULL FOREIGN KEY REFERENCES [User_Info](UserID),
    MessageContent NVARCHAR(MAX) NOT NULL,
    AlertType NVARCHAR(20) NOT NULL,
    IsRead BIT DEFAULT 0,
    CreatedTime DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT CHK_AlertType 
        CHECK (AlertType IN ('超时提醒', '状态变更', '审批提醒', '系统通知'))
);
GO

-- 8. 年度统计表（统计ID、企业ID、年份、总飞行架次、总飞行小时数）
CREATE TABLE Annual_Stats (
    StatID INT IDENTITY(1,1) PRIMARY KEY,
    EnterpriseID INT NOT NULL FOREIGN KEY REFERENCES Enterprise_Info(EnterpriseID),
    Year INT NOT NULL,
    TotalFlights INT DEFAULT 0,
    TotalHours DECIMAL(10,2) DEFAULT 0,
    CreatedTime DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT UQ_EnterpriseYear 
        UNIQUE (EnterpriseID, Year)
);
GO

-- 创建索引
CREATE INDEX IX_User_Username ON [User_Info](Username);
CREATE INDEX IX_User_UserType ON [User_Info](UserType);
CREATE INDEX IX_Enterprise_CompanyName ON Enterprise_Info(CompanyName);
CREATE INDEX IX_FlightPlan_Status ON Flight_Plan(Status);
CREATE INDEX IX_FlightPlan_TimeRange ON Flight_Plan(StartTime, EndTime);
CREATE INDEX IX_Alert_UserUnread ON Alert_Notification(ReviewerID, IsRead);