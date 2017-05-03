/*
Navicat MySQL Data Transfer

Source Server         : 阿里云
Source Server Version : 50624
Source Host           : 120.27.217.224:3306
Source Database       : db_fh

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2017-05-01 17:44:53
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
INSERT INTO `table_cabinet_config` VALUES ('A', '单货柜', '普通机器', '5', '7,6,5,8,8', null);

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
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '1-1', '1', '9', '7.88', '7.88', '7.99', '7.88', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '1-1');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '1-2', '1', '44', '0.01', '0.01', '0.01', '0.01', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-2');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '1-3', '1', '34', '0.01', '0.01', '0.01', '0.01', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '1-3');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '1-4', '1', '45', '0.01', '0.01', '0.01', '0.01', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '1-4');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '1-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-5');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '1-6', '1', '0', '0.00', '0.00', '1.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-6');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '1-7', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-7');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '2-1', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-1');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '2-2', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-2');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '2-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-3');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '2-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-4');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '2-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-5');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '2-6', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-6');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '3-1', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-1');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '3-2', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-2');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '3-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-3');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '3-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-4');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '3-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-5');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '4-1', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-1');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '4-2', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-2');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '4-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-3');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '4-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-4');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '4-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-5');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '4-6', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-6');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '4-7', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-7');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '4-8', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-8');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '5-1', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-1');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '5-2', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-2');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '5-3', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-3');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '5-4', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-4');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '5-5', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-5');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '5-6', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-6');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '5-7', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-7');
INSERT INTO `table_goods_config` VALUES ('ABC123456789', '5-8', '1', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-8');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0101', 'A', '14', '1.22', '1.22', '1.22', '1.22', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '1-1');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0102', 'A', '5', '0.00', '0.01', '0.01', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '1-2');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0103', 'A', '5', '0.00', '0.01', '0.01', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '1-3');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0104', 'A', '5', '0.00', '0.01', '0.01', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '1-4');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0105', 'A', '5', '0.00', '0.01', '0.01', '0.00', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '1-5');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0106', 'A', '5', '0.00', '0.01', '0.01', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '1-6');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0107', 'A', '5', '0.00', '0.01', '0.01', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '1-7');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0201', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-1');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0202', 'A', '0', '0.00', '0.00', '0.00', '0.00', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '2-2');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0203', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '2-3');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0204', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '2-4');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0205', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '2-5');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0206', 'A', '0', '0.00', '0.00', '0.00', '0.00', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '2-6');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0301', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '3-1');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0302', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '3-2');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0303', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '3-3');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0304', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '3-4');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0305', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '3-5');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0401', 'A', '0', '0.00', '0.00', '0.00', '0.00', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '4-1');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0402', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '4-2');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0403', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '4-3');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0404', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-4');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0405', 'A', '0', '0.00', '0.00', '0.00', '0.00', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '4-5');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0406', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '4-6');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0407', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '4-7');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0408', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '4-8');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0501', 'A', '0', '0.00', '0.00', '0.00', '0.00', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '5-1');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0502', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '5-2');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0503', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '5-3');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0504', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-4');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0505', 'A', '0', '0.00', '0.00', '0.00', '0.00', '046aa7f6-00f8-4e5f-8c4e-88488fd78948', '0', '5-5');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0506', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'f0fe516e-3d10-4ea6-ac19-81adf241bcaf', '0', '5-6');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0507', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e87eee2a-7756-499c-81ca-806a928c8e83', '0', '5-7');
INSERT INTO `table_goods_config` VALUES ('ABC000000001', 'A0508', 'A', '0', '0.00', '0.00', '0.00', '0.00', 'e891427d-61a3-4db7-8a7a-36b1ad30620d', '0', '5-8');

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
INSERT INTO `table_goods_status` VALUES ('A0103', 'ABC000000001', '5', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0104', 'ABC000000001', '5', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0105', 'ABC000000001', '5', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0106', 'ABC000000001', '5', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0107', 'ABC000000001', '5', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0201', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0202', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0203', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0204', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0205', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0206', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0301', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0302', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0303', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0304', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0305', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0401', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0402', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0403', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0404', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0405', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0406', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0407', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0408', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0501', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0502', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0503', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0504', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0505', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0506', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0507', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0508', 'ABC000000001', '0', null, null, null, '0', '2017-04-30 17:32:44', 'A');
INSERT INTO `table_goods_status` VALUES ('A0101', 'ABC000000001', '1', '0', null, null, '1', '2017-04-30 18:59:23', null);
INSERT INTO `table_goods_status` VALUES ('A0102', 'ABC000000001', '2', '0', null, null, '1', '2017-04-30 18:59:40', null);

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
INSERT INTO `table_machine` VALUES ('ABC123456789', '12345', '32984fed-48ac-48ad-ac02-2dd028a2beb8', 'cb870f39-92ce-448e-982d-06a563efa64f', 'c4fdeab3-d61b-491e-b223-8b610ee02a5d', '2016-12-01 09:33:21', '2016-12-09 09:33:24', null, 'root', '2016-12-27 17:33:27', 'root', '2016-12-27 21:23:41', null);
INSERT INTO `table_machine` VALUES ('ba37426d-3025-4698-b034-39c1821900da', 'AW009LS123', '56cea9ce-1d87-4e37-9398-e37346276188', '783755de-1a45-4175-84c4-6c7258289002', '7c04a2e6-e03b-4133-b6fd-3690464bcd38', '2016-12-01 12:12:23', '2016-12-31 12:12:26', null, 'root', '2016-12-31 20:12:31', 'root', '2017-01-10 18:16:54', null);
INSERT INTO `table_machine` VALUES ('25795909-ed7a-4c9c-b58f-36d3dd14a552', 'AW001', '32984fed-48ac-48ad-ac02-2dd028a2beb8', 'd82cc1be-0254-470a-b925-615444a806af', '477e407a-f2b9-4598-b5cf-3e1e0067c0ec', '2016-12-01 12:33:10', '2016-12-31 12:33:12', null, 'root', '2016-12-31 20:33:15', null, null, null);
INSERT INTO `table_machine` VALUES ('ABC000000001', 'ABC000000001', 'a69dc85d-bb6b-4831-bca7-fc3a3fe39728', 'cb870f39-92ce-448e-982d-06a563efa64f', 'c4fdeab3-d61b-491e-b223-8b610ee02a5d', '2017-04-27 14:05:45', null, null, 'root', '2017-04-28 22:05:44', null, null, null);

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
INSERT INTO `table_machine_config` VALUES ('ABC123456789', '1', '促销', '1', '1', '1', '0', '1', '0', '1', '1', '1', '0', '12', '4', '5', '5.5', '12', '132', '88', 'root', '2017-03-20 15:16:05', '备注1');
INSERT INTO `table_machine_config` VALUES ('ba37426d-3025-4698-b034-39c1821900da', '1', 'ddd123', '1', '1', '0', '0', '0', '0', '1', '1', '1', '0', '12', '13', '12', '12', '12', '12', '12', 'root', '2017-05-01 15:33:59', null);
INSERT INTO `table_machine_config` VALUES ('25795909-ed7a-4c9c-b58f-36d3dd14a552', '1', '12', '1', '1', '0', '0', '0', '0', '0', '0', '1', '0', '12', '12', '12', '12', '80', '12', '12', 'root', '2017-05-01 15:42:54', null);
INSERT INTO `table_machine_config` VALUES ('ABC000000001', '1', null, '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '1', '2', '0', '0', '0', null, null, 'root', '2017-05-01 16:17:05', null);

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
INSERT INTO `table_mt_goods` VALUES ('32984fed-48ac-48ad-ac02-2dd028a2beb8', 'A');
INSERT INTO `table_mt_goods` VALUES ('56cea9ce-1d87-4e37-9398-e37346276188', 'A');
INSERT INTO `table_mt_goods` VALUES ('a69dc85d-bb6b-4831-bca7-fc3a3fe39728', 'A');

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
INSERT INTO `table_pic` VALUES ('7a38f2eb-4975-43dd-a90c-4f22326f1463', 'bussiness-1_2017010911080209079.png', 'Attachment/bussiness-3_2017010911143147506.png', 'self');
INSERT INTO `table_pic` VALUES ('377cc203-6384-4b0b-9a78-ec206ea80525', 'bussiness-2_2017010911134091817.png', 'Attachment/bussiness-3_2017010911143147506.png', 'self');
INSERT INTO `table_pic` VALUES ('3e59d73d-d5ae-4acb-9765-95c4c077c8d7', 'bussiness-3_2017010911143147506.png', 'Attachment/bussiness-3_2017010911143147506.png', 'self');
INSERT INTO `table_pic` VALUES ('b2d2cb3a-0f97-431b-82e5-75ea96837f69', '8-02_2017010911184910179.png', 'Attachment/bussiness-3_2017010911143147506.png', 'self');

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
INSERT INTO `table_product` VALUES ('e891427d-61a3-4db7-8a7a-36b1ad30620d', '测试商品', '9.99', '450.00', '', null, null, '3e59d73d-d5ae-4acb-9765-95c4c077c8d7', '', '', '', '2017-01-11 13:34:17', 'cb870f39-92ce-448e-982d-06a563efa64f', 'admin');

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
  `sales_number` int(2) DEFAULT NULL,
  `pay_date` datetime DEFAULT NULL,
  `pay_type` varchar(10) DEFAULT NULL,
  `pay_interface` varchar(50) DEFAULT NULL,
  `acquiring_merchant` varchar(20) DEFAULT NULL,
  `trade_no` varchar(50) DEFAULT NULL,
  `payer` varchar(50) DEFAULT NULL,
  `goods_id` varchar(50) DEFAULT NULL,
  `com_id` varchar(50) DEFAULT NULL,
  `trade_amount` decimal(10,2) DEFAULT NULL,
  `trade_status` varchar(2) DEFAULT NULL,
  `random_id` varchar(50) DEFAULT NULL,
  `reality_sale_number` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_sales_cashless
-- ----------------------------
INSERT INTO `table_sales_cashless` VALUES ('4278beb6-8e12-410f-b5f0-b9014dc12d3f', 'ABC123456789', '2017-04-28 15:04:32', '1', '2017-04-28 15:04:32', null, '微信', null, '2017042803042310762386', null, '1-3', null, '0.01', '1', null, null);
INSERT INTO `table_sales_cashless` VALUES ('81a56ac3-d00f-4372-89c1-eaae008d8909', 'ABC123456789', '2017-04-28 15:05:10', '1', '2017-04-28 15:05:10', null, '支付宝', null, '2017042803045788886659', null, '1-4', null, '0.01', '1', null, null);
INSERT INTO `table_sales_cashless` VALUES ('2ba15ca5-1e64-4d7a-b3c9-ee37ee677093', 'ABC123456789', '2017-04-28 15:05:30', '1', '2017-04-28 15:05:30', null, '微信', null, '2017042803011663881253', null, '1-2', null, '0.01', '1', null, null);
INSERT INTO `table_sales_cashless` VALUES ('b574faf9-e074-4e57-8aab-9c09137f5c39', 'ABC123456789', '2017-04-28 16:40:44', '1', '2017-04-28 16:40:44', null, '微信', null, '2017042804403218575866', null, '1-3', null, '0.01', '1', null, null);
INSERT INTO `table_sales_cashless` VALUES ('cee82695-7985-49e7-847b-cf0eb848c3bc', 'ABC123456789', '2017-04-28 16:40:44', '1', '2017-04-28 16:40:44', null, '微信', null, '2017042804403218575866', null, '1-2', null, '0.01', '1', null, null);
INSERT INTO `table_sales_cashless` VALUES ('9171f140-34ad-4f14-9b78-5802b1d43458', 'ABC123456789', '2017-04-28 16:43:05', '1', '2017-04-28 16:43:05', null, '支付宝', null, '2017042804423590445303', null, '1-3', null, '0.01', '1', null, null);
INSERT INTO `table_sales_cashless` VALUES ('86565da3-9c5c-4cc5-a8ba-cfdfcc6fbe93', 'ABC123456789', '2017-04-28 16:43:06', '1', '2017-04-28 16:43:06', null, '支付宝', null, '2017042804423590445303', null, '1-4', null, '0.01', '1', null, null);
INSERT INTO `table_sales_cashless` VALUES ('51af835a-2fe6-4235-a124-e5dc165d7e7e', 'ABC000000001', '2017-04-29 21:50:59', '1', '2017-04-28 22:53:11', null, '支付宝', null, '2017042810524520134971', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('447f2f4a-ea07-40f9-a3cd-495f266c4d6d', 'ABC000000001', '2017-04-29 22:17:34', '1', '2017-04-28 22:55:03', null, '微信', null, '2017042810545620132417', null, 'A0101', null, '0.01', '0', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('b4a12372-a5a7-4c65-aeb9-bfc3fcbc9228', 'ABC000000001', '2017-04-29 22:17:35', '1', '2017-04-28 23:04:24', null, '微信', null, '2017042811040967018660', null, 'A0101', null, '0.01', '0', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('e9906395-d136-43e1-986d-9682f41c05c6', 'ABC000000001', '2017-04-29 22:17:35', '1', '2017-04-28 23:05:44', null, '支付宝', null, '2017042811053084192430', null, 'A0101', null, '0.01', '0', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('45ab6111-50a2-4ab0-9282-0e9adfc5617c', 'ABC000000001', '2017-04-29 22:17:35', '1', '2017-04-29 17:31:58', null, '支付宝', null, '2017042905313432636945', null, 'A0105', null, '0.01', '0', null, '0');
INSERT INTO `table_sales_cashless` VALUES ('c8290a35-cd14-4536-b83d-0b0f8b6f33f2', 'ABC000000001', '2017-04-29 22:43:48', '1', '2017-04-29 22:29:29', null, '微信', null, '2017042910291517012589', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('6c6cecbc-6f71-44b2-be69-b09b60ce3581', 'ABC000000001', '2017-04-29 22:54:05', '1', '2017-04-29 22:46:08', null, '微信', null, '2017042910455993574328', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('0a9ae8d4-f73c-4cd7-9f83-63d6376e07bd', 'ABC000000001', '2017-04-29 22:54:55', '1', '2017-04-29 22:54:44', null, '微信', null, '2017042910543699822531', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('e875136f-f55b-4ff2-a33c-d55c7fe9535b', 'ABC000000001', '2017-04-29 22:56:54', '1', '2017-04-29 22:56:00', null, '支付宝', null, '2017042910554734192206', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('5aa82549-b03c-41bd-bb90-35b975b02651', 'ABC000000001', '2017-04-29 22:59:37', '1', '2017-04-29 22:59:20', null, '支付宝', null, '2017042910590848263557', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('fa15b479-5e8c-4136-970b-c4eb7a02af79', 'ABC000000001', '2017-04-29 23:00:22', '1', '2017-04-29 23:00:07', null, '支付宝', null, '2017042910595473265093', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('eae2849b-a5a6-4dcd-a3f2-7f404a0a4bbc', 'ABC000000001', '2017-04-29 23:01:19', '1', '2017-04-29 23:00:56', null, '微信', null, '2017042911004593572784', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('509cfe3a-506d-4b33-acf6-4ce99d69f01b', 'ABC000000001', '2017-04-29 23:02:10', '1', '2017-04-29 23:01:55', null, '微信', null, '2017042911014802947081', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('57e12d61-e1d1-4096-87cc-de40a99f3c2f', 'ABC000000001', '2017-04-29 23:03:39', '1', '2017-04-29 23:03:19', null, '微信', null, '2017042911031007631949', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('fa6d7308-66f4-4d1f-9432-4c59209ff1bd', 'ABC000000001', '2017-04-29 23:04:19', '1', '2017-04-29 23:04:06', null, '微信', null, '2017042911035934194497', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('6cdaa58c-feff-4de3-a26a-2eb5dc3c3ec6', 'ABC000000001', '2017-04-30 11:12:57', '1', '2017-04-30 11:04:16', null, '微信', null, '2017043011040874824748', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('98306649-221e-44ed-b3aa-355153866b72', 'ABC000000001', '2017-04-30 11:13:25', '1', '2017-04-30 11:13:13', null, '微信', null, '2017043011124729519760', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('5f326ed3-4cd8-4ef7-90b0-e21b41373b5a', 'ABC000000001', '2017-04-30 11:14:21', '1', '2017-04-30 11:14:04', null, '微信', null, '2017043011135609193410', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('20d35473-212c-4b29-aef0-51d212e6d468', 'ABC000000001', '2017-04-30 14:28:02', '1', '2017-04-30 14:27:38', null, '微信', null, '2017043002272251389349', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('bff9562f-54ad-4ab3-8f93-7badcc03b549', 'ABC000000001', '2017-04-30 14:28:02', '1', '2017-04-30 14:27:40', null, '支付宝', null, '2017043002271621692939', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('a55cdfbf-bbb2-4130-96bf-888379562048', 'ABC000000001', '2017-04-30 15:03:41', '1', '2017-04-30 15:03:19', null, '微信', null, '2017043003030974828624', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('d11d8115-7bbe-4288-8663-622fe5edfa64', 'ABC000000001', '2017-04-30 15:07:45', '1', '2017-04-30 15:07:30', null, '微信', null, '2017043003072196699235', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('ee81f4a5-ec99-4bbc-ba53-8ec700ca5f87', 'ABC000000001', '2017-04-30 18:58:12', '1', '2017-04-30 18:57:59', null, '微信', null, '2017043006574807637982', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('19f404f2-a909-4573-b217-8c6b845a4051', 'ABC000000001', '2017-04-30 20:09:27', '1', '2017-04-30 20:07:29', null, '微信', null, '2017043008072062329579', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('8081fcda-fc07-4021-8e17-7e4f87f3976f', 'ABC000000001', '2017-04-30 22:13:35', '1', '2017-04-30 22:13:21', null, '微信', null, '2017043010131410762847', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('96be5584-9c7e-48b1-a61c-90969856a953', 'ABC000000001', '2017-04-30 22:14:46', '1', '2017-04-30 22:14:31', null, '微信', null, '2017043010142387327567', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('f0ffe004-7faa-420f-9828-d4c1a272976a', 'ABC000000001', '2017-04-30 22:15:31', '1', '2017-04-30 22:15:03', null, '微信', null, '2017043010145577943086', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('c7054976-c8ea-487c-9f7a-c7c42ee51f42', 'ABC000000001', '2017-04-30 22:16:07', '1', '2017-04-30 22:15:50', null, '微信', null, '2017043010154304516978', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('a3ac8cfc-48ab-4b97-a41a-0e7554d90bc3', 'ABC000000001', '2017-04-30 22:16:41', '1', '2017-04-30 22:16:27', null, '微信', null, '2017043010161821694666', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('9f0d158f-89ec-478e-b5eb-745b6bf677ff', 'ABC000000001', '2017-05-01 09:15:56', '1', '2017-05-01 09:15:44', null, '微信', null, '2017050109153548265733', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('d6ee06d7-8411-45b2-95ae-c545c96cc5b2', 'ABC000000001', '2017-05-01 09:49:59', '1', '2017-05-01 09:49:44', null, '微信', null, '2017050109493721691471', null, 'A0101', null, '0.01', '2', null, '1');
INSERT INTO `table_sales_cashless` VALUES ('7467561d-29e1-42e5-af35-9573bae3bca0', 'ABC000000001', '2017-05-01 09:50:43', '1', '2017-05-01 09:50:26', null, '微信', null, '2017050109501573268071', null, 'A0101', null, '0.01', '2', null, '1');

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
-- Table structure for `table_to_machine`
-- ----------------------------
DROP TABLE IF EXISTS `table_to_machine`;
CREATE TABLE `table_to_machine` (
  `machine_id` varchar(50) DEFAULT NULL,
  `machine_status` varchar(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of table_to_machine
-- ----------------------------
INSERT INTO `table_to_machine` VALUES ('ABC000000001', 'p');

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
