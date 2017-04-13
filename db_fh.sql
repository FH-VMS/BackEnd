/*
Navicat MySQL Data Transfer

Source Server         : chuang
Source Server Version : 50624
Source Host           : localhost:3306
Source Database       : db_fh

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2017-04-06 09:00:18
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `table_book`
-- ----------------------------
DROP TABLE IF EXISTS `table_book`;
CREATE TABLE `table_book` (
  `id` varchar(50) DEFAULT NULL,
  `book_chinese` varchar(200) DEFAULT NULL,
  `book_english` varchar(200) DEFAULT NULL,
  `book_russian` varchar(200) DEFAULT NULL,
  `value` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_book
-- ----------------------------
INSERT INTO `table_book` VALUES ('rank', '超级管理员', null, null, '1');
INSERT INTO `table_book` VALUES ('rank', '一级客户', null, null, '2');
INSERT INTO `table_book` VALUES ('rank', '二级客户', null, null, '3');
INSERT INTO `table_book` VALUES ('rank', '三级客户', '', '', '4');
INSERT INTO `table_book` VALUES ('rank', '系统管理员', null, null, '0');
INSERT INTO `table_book` VALUES ('typetype', '饮品', null, null, '1');
INSERT INTO `table_book` VALUES ('typetype', '干果', null, null, '2');

-- ----------------------------
-- Table structure for `table_cabinet_config`
-- ----------------------------
DROP TABLE IF EXISTS `table_cabinet_config`;
CREATE TABLE `table_cabinet_config` (
  `cabinet_id` varchar(50) DEFAULT NULL,
  `cabinet_name` varchar(20) DEFAULT NULL,
  `cabinet_type` varchar(20) DEFAULT NULL,
  `layer_number` tinyint(3) DEFAULT NULL,
  `layer_goods_number` varchar(250) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_cabinet_config
-- ----------------------------
INSERT INTO `table_cabinet_config` VALUES ('1', '单货柜', '普通机器', '5', '7,6,5,8,8', null);

-- ----------------------------
-- Table structure for `table_client`
-- ----------------------------
DROP TABLE IF EXISTS `table_client`;
CREATE TABLE `table_client` (
  `client_id` varchar(50) DEFAULT NULL,
  `client_name` varchar(50) DEFAULT NULL,
  `client_status` varchar(20) DEFAULT NULL,
  `client_father_id` varchar(50) DEFAULT NULL,
  `client_type` varchar(20) DEFAULT NULL,
  `client_contect` varchar(50) DEFAULT NULL,
  `client_tel` varchar(50) DEFAULT NULL,
  `client_email` varchar(50) DEFAULT NULL,
  `client_country` varchar(50) DEFAULT NULL,
  `client_currency` varchar(20) DEFAULT NULL,
  `client_address` varchar(100) DEFAULT NULL,
  `creator` varchar(50) DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `updater` varchar(50) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_client
-- ----------------------------
INSERT INTO `table_client` VALUES ('cb870f39-92ce-448e-982d-06a563efa64f', '测试', '可用', 'self', '运营商', '李', '1231232', '3@qq.com', '中国', '人民币', '顶替', null, '2016-12-21 15:57:39', null, null, null);
INSERT INTO `table_client` VALUES ('783755de-1a45-4175-84c4-6c7258289002', '小李', '可用', 'self', '运营商', '小李', '23423423', '3@wee.com', '中国', '人民币', '杭州', null, '2016-12-22 10:32:31', null, null, null);
INSERT INTO `table_client` VALUES ('d82cc1be-0254-470a-b925-615444a806af', '点位一', '可用', '783755de-1a45-4175-84c4-6c7258289002', '点位提供商', '刘', '12312312', null, null, null, null, 'xiaolizikehu', '2016-12-23 09:56:59', null, null, null);
INSERT INTO `table_client` VALUES ('b21a463f-cc82-4dbc-a332-f0be7137d9e8', 'admin1-1', '可用', 'cb870f39-92ce-448e-982d-06a563efa64f', '运营商', 'admin1-1', '2342', '', null, null, null, 'admin1', '2016-12-26 18:37:42', null, null, null);
INSERT INTO `table_client` VALUES ('fcd456a8-2d38-443a-9129-3f7bd6c29352', 'admin1-2', '可用', 'cb870f39-92ce-448e-982d-06a563efa64f', '运营商', 'admin1-2', '12321', null, null, null, null, 'admin1', '2016-12-26 18:37:59', null, null, null);
INSERT INTO `table_client` VALUES ('eb58d861-9d67-42a1-8463-cfda7f44c33e', 'admin2-1', '可用', '0faf2a0c-d26a-4e7e-8b5c-ffc4cb71ac88', '运营商', 'admin2-1', '12312', null, null, null, null, 'admin2', '2016-12-26 18:44:37', null, null, null);
INSERT INTO `table_client` VALUES ('1e11774e-81c3-4d9f-a837-7897b519422e', '杭州中新1', '可用', 'self', '运营商', '杭州中新', '123', null, null, null, null, null, '0001-01-01 00:00:00', 'root', '2016-12-27 14:51:55', null);

-- ----------------------------
-- Table structure for `table_corr_dms`
-- ----------------------------
DROP TABLE IF EXISTS `table_corr_dms`;
CREATE TABLE `table_corr_dms` (
  `id` varchar(50) DEFAULT NULL,
  `corr_dms_id` varchar(50) DEFAULT NULL,
  `corr_menu_id` varchar(50) DEFAULT NULL,
  `corr_add` tinyint(1) DEFAULT NULL,
  `corr_del` tinyint(1) DEFAULT NULL,
  `corr_modify` tinyint(1) DEFAULT NULL,
  `corr_search` tinyint(1) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_corr_dms
-- ----------------------------
INSERT INTO `table_corr_dms` VALUES ('3831b2e6-7e65-4b7e-b527-a1d84a6b3a21', 'a933b45b-1fb4-4cce-91c2-d35fe8f56a93', '2', '1', '0', '0', '0', null);
INSERT INTO `table_corr_dms` VALUES ('5f5f8395-1c04-45b9-86f8-a1dfa1b8e988', 'f3672253-6f0a-422d-b26d-5be3d3865a7c', '9', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('f7c2c8df-ac41-402d-abad-d8eb2393d72a', 'f3672253-6f0a-422d-b26d-5be3d3865a7c', '10', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('8692e1ab-763d-44e7-a831-d589e5d26393', 'f3672253-6f0a-422d-b26d-5be3d3865a7c', '2', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('64aa365c-eb15-4c03-8774-452b0c7e8531', 'f3672253-6f0a-422d-b26d-5be3d3865a7c', '3', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('02f877d4-0109-4c14-81e8-fde9a975815d', '04976ff6-854a-4101-a669-115a0d64ebe2', '5', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('b708c5d9-b227-4f77-8ce5-3ee2f57b11b0', '04976ff6-854a-4101-a669-115a0d64ebe2', '2', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('9381a367-de64-48e8-a61e-254f4afc9e3c', '04976ff6-854a-4101-a669-115a0d64ebe2', '3', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('d20cf5c7-bd29-42d3-bec3-c4fe0ae64ab0', '04976ff6-854a-4101-a669-115a0d64ebe2', '9', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('db4ec1e7-5a4f-4777-aae3-05fcd0ada531', '04976ff6-854a-4101-a669-115a0d64ebe2', '10', '1', '1', '1', '1', null);
INSERT INTO `table_corr_dms` VALUES ('31e32339-949c-432e-a052-164deb4bbe6f', '04976ff6-854a-4101-a669-115a0d64ebe2', '12', '1', '1', '1', '1', null);

-- ----------------------------
-- Table structure for `table_dms`
-- ----------------------------
DROP TABLE IF EXISTS `table_dms`;
CREATE TABLE `table_dms` (
  `id` varchar(50) DEFAULT NULL,
  `dms_name` varchar(50) DEFAULT NULL,
  `rank` tinyint(4) NOT NULL,
  `remark` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_dms
-- ----------------------------
INSERT INTO `table_dms` VALUES ('f3672253-6f0a-422d-b26d-5be3d3865a7c', '一级客户', '2', null);
INSERT INTO `table_dms` VALUES ('04976ff6-854a-4101-a669-115a0d64ebe2', '超级管理员', '1', null);
INSERT INTO `table_dms` VALUES ('a933b45b-1fb4-4cce-91c2-d35fe8f56a93', '二级客户1', '3', null);

-- ----------------------------
-- Table structure for `table_goods_config`
-- ----------------------------
DROP TABLE IF EXISTS `table_goods_config`;
CREATE TABLE `table_goods_config` (
  `machine_id` varchar(50) DEFAULT NULL,
  `tunnel_id` varchar(50) DEFAULT NULL,
  `cabinet_id` varchar(50) DEFAULT NULL,
  `max_puts` int(2) DEFAULT NULL,
  `cash_prices` decimal(10,2) DEFAULT NULL,
  `wpay_prices` decimal(10,2) DEFAULT NULL,
  `alipay_prices` decimal(10,2) DEFAULT NULL,
  `ic_prices` decimal(10,2) DEFAULT NULL,
  `wares_id` varchar(50) DEFAULT NULL,
  `is_used` tinyint(1) DEFAULT NULL,
  `tunnel_position` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_goods_config
-- ----------------------------
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '1-1', '1', '9', '6.44', '6.98', '5.99', '8.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-1');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '1-2', '1', '44', '33.00', '22.00', '11.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-2');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '1-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-3');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '1-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-4');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '1-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-5');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '1-6', '1', '0', '0.00', '0.00', '1.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-6');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '1-7', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-7');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '2-1', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-1');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '2-2', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-2');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '2-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-3');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '2-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-4');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '2-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-5');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '2-6', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-6');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '3-1', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-1');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '3-2', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-2');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '3-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-3');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '3-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-4');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '3-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-5');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '4-1', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-1');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '4-2', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-2');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '4-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-3');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '4-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-4');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '4-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-5');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '4-6', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-6');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '4-7', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-7');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '4-8', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-8');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '5-1', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-1');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '5-2', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-2');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '5-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-3');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '5-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-4');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '5-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-5');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '5-6', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-6');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '5-7', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-7');
INSERT INTO `table_goods_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '5-8', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-8');

-- ----------------------------
-- Table structure for `table_goods_status`
-- ----------------------------
DROP TABLE IF EXISTS `table_goods_status`;
CREATE TABLE `table_goods_status` (
  `goods_stu_id` varchar(50) DEFAULT NULL,
  `machine_id` varchar(50) DEFAULT NULL,
  `curr_stock` int(10) DEFAULT NULL,
  `curr_missing` int(10) DEFAULT NULL,
  `fault_code` char(5) DEFAULT NULL,
  `fault_describe` varchar(200) DEFAULT NULL,
  `curr_status` tinyint(2) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `cabinet_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_goods_status
-- ----------------------------

-- ----------------------------
-- Table structure for `table_ic_account`
-- ----------------------------
DROP TABLE IF EXISTS `table_ic_account`;
CREATE TABLE `table_ic_account` (
  `ic_account` varchar(50) DEFAULT NULL,
  `ic_password` varchar(32) DEFAULT NULL,
  `ic_contacts` varchar(50) DEFAULT NULL,
  `ic_tel` varchar(50) DEFAULT NULL,
  `ic_email` varchar(50) DEFAULT NULL,
  `ic_address` varchar(100) DEFAULT NULL,
  `ic_status` tinyint(2) DEFAULT NULL,
  `client_id` char(10) DEFAULT NULL,
  `creator` varchar(50) DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `updater` varchar(50) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_ic_account
-- ----------------------------

-- ----------------------------
-- Table structure for `table_ic_info1`
-- ----------------------------
DROP TABLE IF EXISTS `table_ic_info1`;
CREATE TABLE `table_ic_info1` (
  `ic_id` varchar(50) DEFAULT NULL,
  `ic_account` varchar(50) DEFAULT NULL,
  `creator` varchar(50) DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `updater` varchar(50) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `corr_remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_ic_info1
-- ----------------------------

-- ----------------------------
-- Table structure for `table_ic_status`
-- ----------------------------
DROP TABLE IF EXISTS `table_ic_status`;
CREATE TABLE `table_ic_status` (
  `ic_id` varchar(50) DEFAULT NULL,
  `ic_period_balance` decimal(10,2) DEFAULT NULL,
  `ic_curr_balance` decimal(10,2) DEFAULT NULL,
  `ic_status` tinyint(2) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_ic_status
-- ----------------------------

-- ----------------------------
-- Table structure for `table_machine`
-- ----------------------------
DROP TABLE IF EXISTS `table_machine`;
CREATE TABLE `table_machine` (
  `machine_id` varchar(50) DEFAULT NULL,
  `device_id` varchar(50) DEFAULT NULL,
  `type_id` varchar(50) DEFAULT NULL,
  `client_id` varchar(50) DEFAULT NULL,
  `usr_account` varchar(50) DEFAULT NULL,
  `start_date` datetime DEFAULT NULL,
  `stop_date` datetime DEFAULT NULL,
  `stop_reason` varchar(200) DEFAULT NULL,
  `creator` varchar(50) DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `updater` varchar(50) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_machine
-- ----------------------------
INSERT INTO `table_machine` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '12345', '32984fed-48ac-48ad-ac02-2dd028a2beb8', 'cb870f39-92ce-448e-982d-06a563efa64f', 'c4fdeab3-d61b-491e-b223-8b610ee02a5d', '2016-12-01 09:33:21', '2016-12-09 09:33:24', null, 'root', '2016-12-27 17:33:27', 'root', '2016-12-27 21:23:41', null);
INSERT INTO `table_machine` VALUES ('ba37426d-3025-4698-b034-39c1821900da', 'AW009LS123', '56cea9ce-1d87-4e37-9398-e37346276188', '783755de-1a45-4175-84c4-6c7258289002', '7c04a2e6-e03b-4133-b6fd-3690464bcd38', '2016-12-01 12:12:23', '2016-12-31 12:12:26', null, 'root', '2016-12-31 20:12:31', 'root', '2017-01-10 18:16:54', null);
INSERT INTO `table_machine` VALUES ('25795909-ed7a-4c9c-b58f-36d3dd14a552', 'AW001', '32984fed-48ac-48ad-ac02-2dd028a2beb8', 'd82cc1be-0254-470a-b925-615444a806af', '477e407a-f2b9-4598-b5cf-3e1e0067c0ec', '2016-12-01 12:33:10', '2016-12-31 12:33:12', null, 'root', '2016-12-31 20:33:15', null, null, null);

-- ----------------------------
-- Table structure for `table_machine_config`
-- ----------------------------
DROP TABLE IF EXISTS `table_machine_config`;
CREATE TABLE `table_machine_config` (
  `machine_id` varchar(50) DEFAULT NULL,
  `mc_status` varchar(10) DEFAULT NULL,
  `mc_activity` varchar(50) DEFAULT NULL,
  `mc_alipay_enable` tinyint(1) DEFAULT NULL,
  `mc_wpay_enable` tinyint(1) DEFAULT NULL,
  `mc_billpay_enable` tinyint(1) DEFAULT NULL,
  `mc_billchange_enable` tinyint(1) DEFAULT NULL,
  `mc_coinpay_enable` tinyint(1) DEFAULT NULL,
  `mc_coinchange_enable` tinyint(1) DEFAULT NULL,
  `mc_upay_enable` tinyint(1) DEFAULT NULL,
  `mc_icpay_enable` tinyint(1) DEFAULT NULL,
  `mc_lift_enable` tinyint(1) DEFAULT NULL,
  `mc_infrared_enable` tinyint(1) DEFAULT NULL,
  `mc_area1_temp` varchar(10) DEFAULT NULL,
  `mc_area2_temp` varchar(10) DEFAULT NULL,
  `mc_area3_temp` varchar(10) DEFAULT NULL,
  `mc_area4_temp` varchar(10) DEFAULT NULL,
  `mc_goods_used` varchar(10) DEFAULT NULL,
  `mc_longitude` varchar(10) DEFAULT NULL,
  `mc_dimension` varchar(10) DEFAULT NULL,
  `updater` varchar(50) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_machine_config
-- ----------------------------
INSERT INTO `table_machine_config` VALUES ('ba37426d-3025-4698-b034-39c1821900da', '1', 'ddd', '1', '1', '0', '0', '0', '0', '1', '1', '1', '0', '12', '13', '12', '12', '12', '12', '12', 'xiaoli', '2016-12-31 20:43:05', null);
INSERT INTO `table_machine_config` VALUES ('248cacdb-6f6e-468c-bd7c-7d294ca5fa31', '1', '促销', '1', '1', '1', '0', '1', '0', '1', '1', '1', '0', '12', '4', '5', '5.5', '12', '132', '88', 'root', '2017-03-20 15:16:05', '备注1');

-- ----------------------------
-- Table structure for `table_machine_log`
-- ----------------------------
DROP TABLE IF EXISTS `table_machine_log`;
CREATE TABLE `table_machine_log` (
  `id` varchar(50) DEFAULT NULL,
  `machine_id` varchar(50) DEFAULT NULL,
  `machine_curr_status` tinyint(2) DEFAULT NULL,
  `machine_run_status` varchar(10) DEFAULT NULL,
  `machine_status_dis` varchar(50) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_machine_log
-- ----------------------------

-- ----------------------------
-- Table structure for `table_machine_status`
-- ----------------------------
DROP TABLE IF EXISTS `table_machine_status`;
CREATE TABLE `table_machine_status` (
  `id` varchar(50) DEFAULT NULL,
  `machine_id` varchar(50) DEFAULT NULL,
  `machine_curr_status` tinyint(2) DEFAULT NULL,
  `machine_issign` tinyint(1) DEFAULT NULL,
  `machine_in_temp` smallint(5) DEFAULT NULL,
  `machine_out_temp` smallint(5) DEFAULT NULL,
  `machine_door_stu` tinyint(1) DEFAULT NULL,
  `machine_area1_temp` smallint(5) DEFAULT NULL,
  `machine_area2_temp` smallint(5) DEFAULT NULL,
  `machine_area3_temp` smallint(5) DEFAULT NULL,
  `machine_area4_temp` smallint(5) DEFAULT NULL,
  `fault_code` char(5) DEFAULT NULL,
  `goods_num` int(4) DEFAULT NULL,
  `fault_describe` varchar(200) DEFAULT NULL,
  `drv1_hw_currvision` varchar(20) DEFAULT NULL,
  `drv1_sf_currvision` varchar(20) DEFAULT NULL,
  `main_sf_currvision` varchar(20) DEFAULT NULL,
  `main_hw_currvision` varchar(20) DEFAULT NULL,
  `drv2_hw_currvision` varchar(20) DEFAULT NULL,
  `drv2_sf_currvision` varchar(20) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_machine_status
-- ----------------------------

-- ----------------------------
-- Table structure for `table_machine_type`
-- ----------------------------
DROP TABLE IF EXISTS `table_machine_type`;
CREATE TABLE `table_machine_type` (
  `id` varchar(50) DEFAULT NULL,
  `type_name` varchar(50) DEFAULT NULL,
  `type_type` varchar(50) DEFAULT NULL,
  `max_goods` int(4) DEFAULT NULL,
  `type_remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_machine_type
-- ----------------------------
INSERT INTO `table_machine_type` VALUES ('a69dc85d-bb6b-4831-bca7-fc3a3fe39728', '奶茶机', '1', '19', '奶茶机');
INSERT INTO `table_machine_type` VALUES ('32984fed-48ac-48ad-ac02-2dd028a2beb8', '传统机器', '2', '12', '传统');
INSERT INTO `table_machine_type` VALUES ('56cea9ce-1d87-4e37-9398-e37346276188', '测试机型', '2', '80', '1234');

-- ----------------------------
-- Table structure for `table_machine_vision`
-- ----------------------------
DROP TABLE IF EXISTS `table_machine_vision`;
CREATE TABLE `table_machine_vision` (
  `id` varchar(50) DEFAULT NULL,
  `mv_type_id` varchar(50) DEFAULT NULL,
  `mv_main_hw_newvision` varchar(20) DEFAULT NULL,
  `mv_main_sf_newvision` varchar(20) DEFAULT NULL,
  `mv_main_sf_path` varchar(100) DEFAULT NULL,
  `mv_drv1_hw_newvision` varchar(20) DEFAULT NULL,
  `mv_drv1_sf_newvision` varchar(20) DEFAULT NULL,
  `mv_drv1_sf_path` varchar(100) DEFAULT NULL,
  `mv_drv2_hw_newvision` varchar(20) DEFAULT NULL,
  `mv_drv2_sf_newvision` varchar(20) DEFAULT NULL,
  `mv_drv2_sf_path` varchar(100) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_machine_vision
-- ----------------------------

-- ----------------------------
-- Table structure for `table_menu`
-- ----------------------------
DROP TABLE IF EXISTS `table_menu`;
CREATE TABLE `table_menu` (
  `menu_id` varchar(50) DEFAULT NULL,
  `menu_name` varchar(50) DEFAULT NULL,
  `menu_father` varchar(50) DEFAULT NULL,
  `url` varchar(200) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_menu
-- ----------------------------
INSERT INTO `table_menu` VALUES ('1', '业务管理', null, null, null);
INSERT INTO `table_menu` VALUES ('2', '客户列表', '1', 'customer', null);
INSERT INTO `table_menu` VALUES ('3', '用户列表', '1', 'user', null);
INSERT INTO `table_menu` VALUES ('4', '权限配置', '1', 'auth', null);
INSERT INTO `table_menu` VALUES ('5', '商品列表', '1', 'productlist', null);
INSERT INTO `table_menu` VALUES ('6', '商品配置', '1', null, null);
INSERT INTO `table_menu` VALUES ('7', '商品入库', '1', null, null);
INSERT INTO `table_menu` VALUES ('8', '商品图片列表', '1', null, null);
INSERT INTO `table_menu` VALUES ('9', '机器管理', '1', 'machinelist', null);
INSERT INTO `table_menu` VALUES ('10', '机器配置', '1', 'machineconfig', null);
INSERT INTO `table_menu` VALUES ('12', '货道配置', '1', 'tunnelconfig', null);
INSERT INTO `table_menu` VALUES ('13', '货道信息', '1', 'tunnelinfo', null);
INSERT INTO `table_menu` VALUES ('14', 'IC卡用户表', '1', null, null);
INSERT INTO `table_menu` VALUES ('15', 'IC卡列表', '1', null, null);
INSERT INTO `table_menu` VALUES ('16', 'IC卡充值', '1', null, null);
INSERT INTO `table_menu` VALUES ('17', '运营查看', null, null, null);
INSERT INTO `table_menu` VALUES ('18', '客户运营信息', '17', 'customerinfo', null);
INSERT INTO `table_menu` VALUES ('19', '用户运营信息', '17', 'userinfo', null);
INSERT INTO `table_menu` VALUES ('20', '机器配置信息', '17', 'machineconfiginfo', null);
INSERT INTO `table_menu` VALUES ('21', '机器货道信息', '17', 'tunnelinfo', null);
INSERT INTO `table_menu` VALUES ('22', '机器实时状态', '17', null, null);
INSERT INTO `table_menu` VALUES ('23', '机器当前库存', '17', null, null);
INSERT INTO `table_menu` VALUES ('24', '机器位置地图', '17', null, null);
INSERT INTO `table_menu` VALUES ('25', '商品低库存', '17', null, null);
INSERT INTO `table_menu` VALUES ('26', '补货单生成', '17', null, null);
INSERT INTO `table_menu` VALUES ('27', '机器故障单', '17', null, null);
INSERT INTO `table_menu` VALUES ('28', '实时销售记录', '17', null, null);
INSERT INTO `table_menu` VALUES ('29', '非现金销售记录', '17', 'salecashless', null);
INSERT INTO `table_menu` VALUES ('30', 'IC卡销售记录', '17', null, null);
INSERT INTO `table_menu` VALUES ('31', 'IC卡黑名单账户', '17', null, null);
INSERT INTO `table_menu` VALUES ('32', '运营设置', null, null, null);
INSERT INTO `table_menu` VALUES ('33', '补货修改', '32', null, null);
INSERT INTO `table_menu` VALUES ('34', '货道价格修改', '32', null, null);
INSERT INTO `table_menu` VALUES ('35', '报表管理\r\n', null, null, null);
INSERT INTO `table_menu` VALUES ('37', '用户参数', '36', null, null);
INSERT INTO `table_menu` VALUES ('38', '密码修改', '36', null, null);
INSERT INTO `table_menu` VALUES ('39', '系统设置', null, null, null);
INSERT INTO `table_menu` VALUES ('40', '商品类型表', '39', null, null);
INSERT INTO `table_menu` VALUES ('41', '商品供应商表', '39', null, null);
INSERT INTO `table_menu` VALUES ('42', '支付配置', '39', null, null);
INSERT INTO `table_menu` VALUES ('43', '货柜列表', '39', null, null);
INSERT INTO `table_menu` VALUES ('44', '机型列表', '39', 'machinetype', null);
INSERT INTO `table_menu` VALUES ('45', '机型配置', '39', '', null);
INSERT INTO `table_menu` VALUES ('46', '远程更新(指定机器)', '39', null, null);
INSERT INTO `table_menu` VALUES ('47', '远程更新(指定机型)', '39', null, null);
INSERT INTO `table_menu` VALUES ('36', '用户设置', null, null, null);
INSERT INTO `table_menu` VALUES ('11', '机器迁移', '1', null, null);

-- ----------------------------
-- Table structure for `table_mt_goods`
-- ----------------------------
DROP TABLE IF EXISTS `table_mt_goods`;
CREATE TABLE `table_mt_goods` (
  `machine_type_id` varchar(50) DEFAULT NULL,
  `cabinet_type_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_mt_goods
-- ----------------------------
INSERT INTO `table_mt_goods` VALUES ('32984fed-48ac-48ad-ac02-2dd028a2beb8', '1');
INSERT INTO `table_mt_goods` VALUES ('56cea9ce-1d87-4e37-9398-e37346276188', '1');

-- ----------------------------
-- Table structure for `table_operation`
-- ----------------------------
DROP TABLE IF EXISTS `table_operation`;
CREATE TABLE `table_operation` (
  `id` varchar(50) DEFAULT NULL,
  `opt_content` varchar(100) DEFAULT NULL,
  `opt_date` datetime DEFAULT NULL,
  `operator` varchar(50) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_operation
-- ----------------------------

-- ----------------------------
-- Table structure for `table_pay_config`
-- ----------------------------
DROP TABLE IF EXISTS `table_pay_config`;
CREATE TABLE `table_pay_config` (
  `id` varchar(50) NOT NULL,
  `client_id` char(10) DEFAULT NULL,
  `pay_type` varchar(20) DEFAULT NULL,
  `pay_account` varchar(100) DEFAULT NULL,
  `pay_merchant` varchar(100) DEFAULT NULL,
  `pay_publickey` varchar(200) DEFAULT NULL,
  `pay_privatekey` varchar(200) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_pay_config
-- ----------------------------

-- ----------------------------
-- Table structure for `table_pic`
-- ----------------------------
DROP TABLE IF EXISTS `table_pic`;
CREATE TABLE `table_pic` (
  `pic_id` varchar(50) NOT NULL,
  `pic_name` varchar(50) DEFAULT NULL,
  `pic_path` varchar(200) DEFAULT NULL,
  `client_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_pic
-- ----------------------------
INSERT INTO `table_pic` VALUES ('7a38f2eb-4975-43dd-a90c-4f22326f1463', 'bussiness-1_2017010911080209079.png', 'Attachment/bussiness-1_2017010911080209079.png', 'self');
INSERT INTO `table_pic` VALUES ('377cc203-6384-4b0b-9a78-ec206ea80525', 'bussiness-2_2017010911134091817.png', 'Attachment/bussiness-2_2017010911134091817.png', 'self');
INSERT INTO `table_pic` VALUES ('3e59d73d-d5ae-4acb-9765-95c4c077c8d7', 'bussiness-3_2017010911143147506.png', 'Attachment/bussiness-3_2017010911143147506.png', 'self');
INSERT INTO `table_pic` VALUES ('b2d2cb3a-0f97-431b-82e5-75ea96837f69', '8-02_2017010911184910179.png', 'Attachment/8-02_2017010911184910179.png', 'self');

-- ----------------------------
-- Table structure for `table_product`
-- ----------------------------
DROP TABLE IF EXISTS `table_product`;
CREATE TABLE `table_product` (
  `wares_id` varchar(50) DEFAULT NULL,
  `wares_name` varchar(50) DEFAULT NULL,
  `wares_unitprice` decimal(8,2) DEFAULT NULL,
  `wares_weight` decimal(10,2) DEFAULT NULL,
  `wares_specifications` varchar(50) DEFAULT NULL,
  `wares_manufacture_date` datetime DEFAULT NULL,
  `wares_quality_period` datetime DEFAULT NULL,
  `pic_id` varchar(50) DEFAULT NULL,
  `wares_type_id` varchar(50) DEFAULT NULL,
  `supplier_id` varchar(50) DEFAULT NULL,
  `wares_description` varchar(500) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `client_id` varchar(50) DEFAULT NULL,
  `creator` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_product
-- ----------------------------
INSERT INTO `table_product` VALUES ('046aa7f6-00f8-4e5f-8c4e-88488fd78948', '乐事薯片', '12.59', '380.00', '380g/袋', '2016-12-30 16:00:00', '2017-12-31 16:00:00', '7a38f2eb-4975-43dd-a90c-4f22326f1463', '', '', null, '2017-01-09 14:45:53', 'self', 'root');
INSERT INTO `table_product` VALUES ('f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '矿泉水', '2.50', '500.00', '', null, null, '7a38f2eb-4975-43dd-a90c-4f22326f1463', '', '', '', '2017-01-11 13:07:44', 'self', 'root');
INSERT INTO `table_product` VALUES ('e87eee2a-7756-499c-81ca-806a928c8e83', '小李的商品', '8.99', '350.00', '', null, null, '7a38f2eb-4975-43dd-a90c-4f22326f1463', '', '', '', '2017-01-11 13:29:26', '783755de-1a45-4175-84c4-6c7258289002', 'xiaoli');
INSERT INTO `table_product` VALUES ('e891427d-61a3-4db7-8a7a-36b1ad30620d', 'admin的商品', '9.99', '450.00', '', null, null, '3e59d73d-d5ae-4acb-9765-95c4c077c8d7', '', '', '', '2017-01-11 13:34:17', 'cb870f39-92ce-448e-982d-06a563efa64f', 'admin');

-- ----------------------------
-- Table structure for `table_product_config`
-- ----------------------------
DROP TABLE IF EXISTS `table_product_config`;
CREATE TABLE `table_product_config` (
  `wares_config_id` varchar(50) DEFAULT NULL,
  `wares_id` varchar(50) DEFAULT NULL,
  `wares_config_name` varchar(50) DEFAULT NULL,
  `low_missing` int(10) DEFAULT NULL,
  `low_missing_alarm` tinyint(1) DEFAULT NULL,
  `purchase_price` decimal(10,2) DEFAULT NULL,
  `price_unit` varchar(20) DEFAULT NULL,
  `wares_status` tinyint(2) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `wares_config_remark` varchar(250) DEFAULT NULL,
  `client_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_product_config
-- ----------------------------

-- ----------------------------
-- Table structure for `table_product_stock`
-- ----------------------------
DROP TABLE IF EXISTS `table_product_stock`;
CREATE TABLE `table_product_stock` (
  `wares_stock_id` varchar(50) DEFAULT NULL,
  `wares_id` varchar(50) DEFAULT NULL,
  `wares_stock_name` varchar(50) DEFAULT NULL,
  `wares_stock_number` int(10) DEFAULT NULL,
  `wares_stock_unit` varchar(50) DEFAULT NULL,
  `wares_stock_status` tinyint(2) DEFAULT NULL,
  `client_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_product_stock
-- ----------------------------

-- ----------------------------
-- Table structure for `table_product_storage`
-- ----------------------------
DROP TABLE IF EXISTS `table_product_storage`;
CREATE TABLE `table_product_storage` (
  `wares_stg_id` varchar(50) DEFAULT NULL,
  `wares_id` varchar(50) DEFAULT NULL,
  `wares_stg_number` int(10) DEFAULT NULL,
  `wares_stg_date` datetime DEFAULT NULL,
  `wares_stg_opt` varchar(50) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL,
  `client_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_product_storage
-- ----------------------------

-- ----------------------------
-- Table structure for `table_product_supplier`
-- ----------------------------
DROP TABLE IF EXISTS `table_product_supplier`;
CREATE TABLE `table_product_supplier` (
  `supplier_id` varchar(50) DEFAULT NULL,
  `supplier_name` varchar(50) DEFAULT NULL,
  `supplier_address` varchar(100) DEFAULT NULL,
  `supplier_contect` varchar(50) DEFAULT NULL,
  `supplier_tel` varchar(50) DEFAULT NULL,
  `supplier_fax` varchar(50) DEFAULT NULL,
  `supplier_account` varchar(50) DEFAULT NULL,
  `supplier_settlement` tinyint(2) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL,
  `client_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_product_supplier
-- ----------------------------

-- ----------------------------
-- Table structure for `table_product_type`
-- ----------------------------
DROP TABLE IF EXISTS `table_product_type`;
CREATE TABLE `table_product_type` (
  `wares_type_id` varchar(50) DEFAULT NULL,
  `wares_type_name` varchar(50) DEFAULT NULL,
  `wares_type_remark` varchar(250) DEFAULT NULL,
  `client_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_product_type
-- ----------------------------

-- ----------------------------
-- Table structure for `table_sales_cash`
-- ----------------------------
DROP TABLE IF EXISTS `table_sales_cash`;
CREATE TABLE `table_sales_cash` (
  `sales_no` varchar(50) DEFAULT NULL,
  `machine_id` varchar(50) DEFAULT NULL,
  `sales_date` datetime DEFAULT NULL,
  `sales_type` tinyint(2) DEFAULT NULL,
  `goods_id` varchar(50) DEFAULT NULL,
  `com_id` varchar(50) DEFAULT NULL,
  `sales_number` int(10) DEFAULT NULL,
  `sales_prices` decimal(10,2) DEFAULT NULL,
  `pay_way` tinyint(2) DEFAULT NULL,
  `trade_no` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_sales_cash
-- ----------------------------

-- ----------------------------
-- Table structure for `table_sales_cashless`
-- ----------------------------
DROP TABLE IF EXISTS `table_sales_cashless`;
CREATE TABLE `table_sales_cashless` (
  `sales_ic_id` varchar(50) NOT NULL,
  `machine_id` varchar(50) DEFAULT NULL,
  `sales_date` datetime DEFAULT NULL,
  `sales_number` int(10) DEFAULT NULL,
  `pay_date` datetime DEFAULT NULL,
  `pay_type` varchar(10) DEFAULT NULL,
  `pay_interface` varchar(50) DEFAULT NULL,
  `acquiring_merchant` varchar(20) DEFAULT NULL,
  `trade_no` varchar(50) DEFAULT NULL,
  `payer` varchar(50) DEFAULT NULL,
  `goods_id` varchar(50) DEFAULT NULL,
  `com_id` varchar(50) DEFAULT NULL,
  `trade_amount` decimal(10,2) DEFAULT NULL,
  `trade_status` tinyint(2) DEFAULT NULL,
  `random_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_sales_cashless
-- ----------------------------

-- ----------------------------
-- Table structure for `table_sales_ic`
-- ----------------------------
DROP TABLE IF EXISTS `table_sales_ic`;
CREATE TABLE `table_sales_ic` (
  `sales_ic_id` varchar(50) DEFAULT NULL,
  `machine_id` varchar(50) DEFAULT NULL,
  `sales_date` datetime DEFAULT NULL,
  `sales_number` int(10) DEFAULT NULL,
  `pay_date` datetime DEFAULT NULL,
  `pay_type` tinyint(2) DEFAULT NULL,
  `pay_interface` varchar(50) DEFAULT NULL,
  `acquiring_merchant` varchar(20) DEFAULT NULL,
  `trade_no` varchar(50) DEFAULT NULL,
  `payer` varchar(50) DEFAULT NULL,
  `goods_id` varchar(50) DEFAULT NULL,
  `com_id` varchar(50) DEFAULT NULL,
  `trade_amount` decimal(10,2) DEFAULT NULL,
  `trade_status` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_sales_ic
-- ----------------------------

-- ----------------------------
-- Table structure for `table_user`
-- ----------------------------
DROP TABLE IF EXISTS `table_user`;
CREATE TABLE `table_user` (
  `id` varchar(50) DEFAULT NULL,
  `usr_account` varchar(50) DEFAULT NULL,
  `usr_access_id` varchar(50) DEFAULT NULL,
  `usr_name` varchar(50) DEFAULT NULL,
  `usr_pwd` char(32) DEFAULT NULL,
  `usr_client_id` varchar(50) DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `creator` varchar(50) DEFAULT NULL,
  `enddate` datetime DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL,
  `sts` tinyint(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_user
-- ----------------------------
INSERT INTO `table_user` VALUES ('d71981a4-6a1d-414d-8238-16cbc05f5fd7', 'root', '', '系统管理员', '123', 'self', null, null, null, null, '100');
INSERT INTO `table_user` VALUES ('477e407a-f2b9-4598-b5cf-3e1e0067c0ec', 'ttt2', 'f3672253-6f0a-422d-b26d-5be3d3865a7c', 'ttt', '123', 'd82cc1be-0254-470a-b925-615444a806af', '2016-12-26 12:54:01', null, null, 'ttt', '1');
INSERT INTO `table_user` VALUES ('c4fdeab3-d61b-491e-b223-8b610ee02a5d', 'admin', '04976ff6-854a-4101-a669-115a0d64ebe2', 'admin', '123', 'cb870f39-92ce-448e-982d-06a563efa64f', '2016-12-26 14:40:44', null, null, 'admin', '1');
INSERT INTO `table_user` VALUES ('7c04a2e6-e03b-4133-b6fd-3690464bcd38', 'xiaoli', '04976ff6-854a-4101-a669-115a0d64ebe2', 'xiaoli', '123', '783755de-1a45-4175-84c4-6c7258289002', '2016-12-26 14:41:32', null, null, 'xiaoli', '1');
INSERT INTO `table_user` VALUES ('de47e39c-dea9-4b58-b722-7815c22168df', 'sss', 'a933b45b-1fb4-4cce-91c2-d35fe8f56a93', 'sss', '123', '8d3918d5-1115-4586-a346-f4e6e7ee8c6c', '2016-12-26 14:49:52', null, null, 'sss', '1');
INSERT INTO `table_user` VALUES ('f9854aa5-7951-4772-947d-879df3c66dea', 'admin1', 'f3672253-6f0a-422d-b26d-5be3d3865a7c', 'admin1', '123', 'ba1b545f-c09d-41ab-9a1d-a9f1a1ce8593', '2016-12-26 14:52:18', null, null, 'admin1', '1');
INSERT INTO `table_user` VALUES ('5754f7ef-cb39-4826-806c-4fd33214c0a1', 'admin1', 'f3672253-6f0a-422d-b26d-5be3d3865a7c', '', '123', 'e0b01c5a-abed-43f3-87f8-93a16358dff6', '2016-12-26 18:36:50', null, null, '', '1');
INSERT INTO `table_user` VALUES ('772a3f41-c8b0-44a3-83bd-764e372dfd03', 'admin2', 'f3672253-6f0a-422d-b26d-5be3d3865a7c', '', '123', '0faf2a0c-d26a-4e7e-8b5c-ffc4cb71ac88', '2016-12-26 18:37:03', null, null, '', '1');
INSERT INTO `table_user` VALUES ('0a1e92c4-fa17-43e1-a4a2-73a8ab54d82f', 'hzzx', '04976ff6-854a-4101-a669-115a0d64ebe2', 'hzzx', '123', '1e11774e-81c3-4d9f-a837-7897b519422e', '2016-12-27 14:52:25', null, null, '123', '1');

-- ----------------------------
-- Table structure for `table_usr_status`
-- ----------------------------
DROP TABLE IF EXISTS `table_usr_status`;
CREATE TABLE `table_usr_status` (
  `usr_stu_id` varchar(50) DEFAULT NULL,
  `usr_stu_account` varchar(50) DEFAULT NULL,
  `usr_stu_stu` tinyint(2) DEFAULT NULL,
  `usr_stu_balance` decimal(16,2) DEFAULT NULL,
  `usr_stu_reachdate` datetime DEFAULT NULL,
  `usr_stu_reachip` char(20) DEFAULT NULL,
  `usr_stu_machine_total` int(6) DEFAULT NULL,
  `usr_stu_machine_expire` int(6) DEFAULT NULL,
  `usr_stu_machine_stop` int(6) DEFAULT NULL,
  `usr_stu_machine_fault` int(6) DEFAULT NULL,
  `usr_stu_need_restock` int(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_usr_status
-- ----------------------------

-- ----------------------------
-- Function structure for `getClientLst`
-- ----------------------------
DROP FUNCTION IF EXISTS `getClientLst`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getClientLst`(rootId VARCHAR(50)) RETURNS varchar(1000) CHARSET utf8
BEGIN
      DECLARE sTemp VARCHAR(1000);
      DECLARE sTempChd VARCHAR(1000);
    
       SET sTemp = '$';
       SET sTempChd =cast(rootId as CHAR);
    
      WHILE sTempChd is not null DO
         SET sTemp = concat(sTemp,',',sTempChd);
         SELECT group_concat(client_id) INTO sTempChd FROM table_client where FIND_IN_SET(client_father_id,sTempChd)>0;
      END WHILE;
       RETURN sTemp;
     END
;;
DELIMITER ;
