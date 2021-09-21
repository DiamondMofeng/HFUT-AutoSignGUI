# coding=utf-8

import random
import time
import json
import smtplib
from email.header import Header
from email.mime.text import MIMEText
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
# from selenium.webdriver.common.desired_capabilities import DesiredCapabilities
# from selenium.webdriver.support.ui import WebDriverWait
from time import sleep
# import os


# ####DEF PART#####


def isElementExists_byXpath(browser, elementXpath):
    isExists = True
    try:
        browser.find_element_by_xpath(elementXpath)
        # print("今日未填报")
        return isExists
    except:
        isExists = False
        # print("今日已填报或未找到入口")
        return isExists


def emailModule(subject, text):
    # 打开config.json并读取是否启用邮件模块，以及其他信息
    configFile = open("config.json", "r", encoding="utf-8")
    config = json.loads(configFile.read())
    enable = config["是否启用邮件模块"]
    if enable == False:
        return
    mailserver = config["邮箱的smtp服务器地址"]
    sender = config["发件人邮箱账号"]
    passwd = config["发件人邮箱授权码"]
    receiver = config["收件人邮箱账号"]

    configFile.close()

    # 邮件内容部分

    msg = MIMEText(text)  # 主体，同时赋予文本
    msg['From'] = Header("HFUT-自动打卡", 'utf-8')  # 发送者昵称
    # msg['To'] = Header("", 'utf-8')  # 接收者昵称
    msg['Subject'] = Header(subject, 'utf-8')  # 标题

    # 邮件发送部分

    server = smtplib.SMTP(mailserver, 25)  # 发件人邮箱中的SMTP服务器，端口是25
    server.login(sender, passwd)  # 发件人邮箱账号、邮箱授权码
    # msg.as_string()中as_string()是将msg(MIMEText或MIMEMultipart对象)变为str。
    server.sendmail(sender, receiver, msg.as_string())
    server.quit()


# #####MAIN######

# 隐藏窗口部分

br: webdriver
chrome_options = Options()
# chrome_options.add_argument('--headless')
# chrome_options.add_argument('--disable-gpu')

# 服务器自用部分:隐藏窗口
'''
chrome_options = Options()
chrome_options.add_argument('--headless')  #
chrome_options.add_argument('disable-dev-shm-usage')
chrome_options.add_argument('--disable-gpu')
chrome_options.add_argument('no-sandbox')
'''

try:
    # 从config.json读取驱动路径
    configFile = open("config.json", "r", encoding="utf-8")
    configInfo = json.loads(configFile.read())
    configFile.close()
    PATH = configInfo['驱动路径']
    # 打开浏览器
    br = webdriver.Chrome(executable_path=PATH, options=chrome_options)

    # 进入学生疫情信息收集页面

    br.get("http://stu.hfut.edu.cn/xsfw/sys/xsyqxxsjapp/*default/index.do#/mrbpa")
    sleep(random.randint(5, 10))
    br.find_element_by_xpath("/html/body/div[1]/div/div/div/div/button[1]").click()
    sleep(random.randint(5, 10))

    # 从config.json读取用户名(学号)，密码并登录

    username = configInfo['学号']
    password = configInfo['密码']

    # 填入学号密码

    br.find_element_by_id("username").send_keys(username)
    br.find_element_by_id("pwd").send_keys(password)

    # 点击登录

    br.find_element_by_id("sb2").click()
    sleep(random.randint(5, 10))
    if isElementExists_byXpath(br, '/html/body/div[2]/div/div[2]/form/div[2]/div/span/div/span'):  # 登陆失败
        br.close()
        print("学号/密码错误！")
        raise Exception

    # 判断今日是否未填报

    if not isElementExists_byXpath(br, '//*[@id="save"]'):

        if isElementExists_byXpath(br, '/html/body/main/article/section/div/div[3]/div[2]/div/div[4]/div['
                                       '2]/div/table/tbody/tr[1]/td[2]/a[1]'):
            print("自动打卡失败！原因：可能已打过卡""，若不放心请登录今日校园检查")
            emailModule("自动打卡失败！原因：可能已打过卡", "可能今日已打过卡，若不放心请登录今日校园检查")
        else:
            print("自动打卡失败！原因：可能程序出现故障"".今日请手动打卡，闲时可向作者反馈问题")
            emailModule("自动打卡失败！原因：可能程序出现故障", "可能程序出现故障，今日请手动打卡，闲时可向作者反馈问题")

    else:
        # 点击保存按钮，提交打卡信息
        br.find_element_by_xpath('//*[@id="save"]').click()
        print("自动打卡成功！")
        emailModule("自动打卡成功！", username + "于" + time.strftime("%Y-%m-%d-%H时%M分%S秒", time.localtime()) + "进行了自动打卡")

    br.close()
except:
    try:
        br.close()
        print("自动打卡失败！"" 程序运行出现错误")
        emailModule("自动打卡失败！", "程序运行出现错误")
    except:
        print("自动打卡失败！""Selenium配置出现问题，打开模拟浏览器失败")
        emailModule("自动打卡失败！", "程序运行出现错误")
