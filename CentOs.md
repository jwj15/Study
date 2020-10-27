### censos8 한글입력
>관리자 접속
>yum install ibus-hangul
>재시작후 한국어(Hangul)로 입력소스 교체

### selinux 해제
>sudo vi /etc/sysconfig/selinux (gedit <-> vi)  
>SELINUX=enforcing ==> disabled 로 수정후 재부팅

### vi 사용법
>`i` 또는 `a` 입력모드 `esc` 입력모드취소  
>`u` 한글자 `U` 한줄 명령 취소  
>`x` 글자삭제(del)  
>`dd` 행삭제  
>`yy` 행복사 이후 `p` 붙여넣기  
>`:q`나가기  
>`:w` 저장  
>`:set number` 줄번호 달기  
>`/문자열` 해당문자열 찾기(커서이후로)  
> `gg` 처음으로 
> `shift + g` 마지막으로    

### 초기 업데이트 
>yum update or upgrade

### sudo 사용자 등록
>root 전환후   
>chmod u+w /etc/sudoers  
>vi /etc/sudoers  
>추가후
>chmod u-w /etc/sudoers  
>wheel그룹은 자동으로 등록되있지만 임의로 그룹에 사용자를 등록하면 설정해줘야한다.  
>그룹은 앞에 %붙여서 등록  

### ssh 포트 변경
> ssh 포트는 변경하지 않으면 해킹의 위협이 크다 
> sudo vi /etc/ssh/sshd_config  
> Port XXX 추가 및 방화벽 포트 변경추가 
> sshd 서비스 재시작;

### 고정아이피 등록 
>vi /etc/sysconfig/network-scripts/ifcfg-eth0 // 뒤에 이름은 다를수 있다  
>BOOTPROTO="static"  
>IPADDR="192.168.0.205"  
>GATEWAY="192.168.0.1"  
>DNS1="168.126.63.1"  
>DNS2="168.126.63.2"  

### vnc server 추가
>yum install tigervnc-server  
>cp /lib/systemd/system/vncserver@.service /etc/systemd/system/vncserver@:1.service  
>vi /etc/systemd/system/vncserver@:1.service  
>=> \<user>에 사용할 유저입력  
>ExecStart=/usr/sbin/runuser -l \<user> -c "/usr/bin/vncserver %i"  
>PIDFile=/home/\<user>/.vnc/%H%i.pid  

>vncpasswd // 패스워드 변경  
>systemctl daemon-reload // 설정파일 재시작  
>systemctl enable vncserver@:1 // 서비스 활성화  
>vncserver // 서비스 시작 첫 시작시 접속할 비번입력  
>방화벽 포트 열어주고 5901~5903정도 열어줌 (서비스 vnc-server선택함)  
>클라이언트에 vncviewer설치후 아이피:포트로접속  
```
7.7이후 서비스설정
[Unit]

Description=Remote desktop service (VNC)
After=syslog.target network.target

[Service]
Type=simple

# Clean any existing files in /tmp/.X11-unix environment
ExecStartPre=/bin/sh -c '/usr/bin/vncserver -kill %i > /dev/null 2>&1 || :'
ExecStart=/usr/bin/vncserver_wrapper jjang %i -geometry 1600x900
ExecStop=/bin/sh -c '/usr/bin/vncserver -kill %i > /dev/null 2>&1 || :'

[Install]
WantedBy=multi-user.target
```

### name server 추가
>vi /etc/resolv.conf  
>nameserver 168.126.63.1      (kt)

### 명령어 모음
> `ls` ==> dir명령 `-a` ==> 숨김파일포함 `-l` ==> 자세히출력  
> `cd` ==> 디렉토리 이동  `~jjang` ==> jjang의홈으로  
> `pwd` ==> 현재 작업경로 출력  
> `rm` ==> 파일 삭제 `-i` ==> 확인메세지 `-f` ==> 확인없이 바로 삭제 `-r` ==> 디렉토리 삭제  
> `cp` ==> 복사 // **원본 카피순서** `-r` ==> 디렉토리복사  
> `mv` ==> 이동 // **원본 경로or저장될이름**  
> `mkdir` ==> 디렉토리 생성 `-p` ==> 부모디렉토리 자동 생성  
> `rmdir` ==> 디렉토리 삭제(빈 디렉토리만 가능)  
> `cat` ==> 파일내용 화면에 출력  
> `more` ==> 텍스트파일 페이지단위 출력 //스페이스바 ==>다음, b키 ==>이전  
> `less` ==> more 업그레이드 버전 화살표나 페이지업다운키 사용가능  
> `clear` ==> 화면 지우기  
> `file` ==> 파일 종류 알려줌  

### 사용자 및 그룹관리
> `사용자`: /etc/passwd     `그룹`: /etc/group  
> useradd 사용자 -- 사용자 추가 // -U 1111 --사용자아이디1111 // -g 그룹1 -- 그룹1에 포함(그룹1존재해야함) // -d /newhome -- 홈디텍토리 /newhome으로  
> passwd 계정  -- 암호변경  
> usermod -- 사용자 속성 변경 옵션은 useradd와 동일  
> userdel  -- 사용자 삭제 // -r 홈디렉토리까지 삭제  
> groups -- 사용자 소속 그룹 출력  
> groupadd -- 그룹생성 // -g 2222 -- 그룹아이디 2222  
> groupmod -n -- 그룹이름 변경  
> groupdel -- 그룹 삭제  
> grpasswd -- 그룹 암호 설정 // -A 유저 그룹 -- 유저를 그룹의 관리자로 지정 // -a 유저 그룹 -- 유저를 그룹에 추가 // -d 유저 그룹 -- 그룹에서 유저삭제  
> cat /etc/passwd - - 유저리스트  
> sudo gpasswd -a user group -- 그룹에 추가  
> sudo gpasswd -d user group -- 그룹에서 삭제  

### 파일 소유권
> rwx 4 2 1  
> chmod 777 파일 -- 파일 권한 777로 변경  
> chmod u+w -- user에게 쓰기권한 부여 u유저,g그룹,o그외사용자 +부여-삭제 r읽기w쓰기x실행  
> chown 사용자.그룹 파일 -- 소유권 변경  // -R -- 하위 폴더 및 파일포함
> chgrp 그룹 파일 -- 그룹 소유권변경  

### 패키지 설치 명령어
> rpm -Uvh 패키지파일이름.rpm -- U설치되있다면 업그레이드,v설치과정확인,h진행과정#기호로 출력  
> rpm -qa 패키지이름 -- 패키지 설치되있는지 확인  
> rpm -qf 패키지절대경로 -- 설치된 파일이 어느 패키지에 포함된 것인지 확인  
> rpm -ql 패키지이름 -- 패키지에 포함된 파일확인  
> rpm -qi 패키지이름 -- 설치된 패키지 상세정보  
> rpm -qlp 패키지이름.rpm -- 패키지파일 안에 포함된 파일 확인  
> rpm -qip 패키지이름.rpm -- 패키지 파일 상세정보  

**\* yum은 rpm 명령의 의존성 문제를 해결**  
> yum -y install 패키지이름 -- 패키지 설치 -y옵션은 질의시 무조건 yes  
> yum localinstall rmp파일.rpm -- 의존성 파일은 인터넷에서 알아서 받음(rpm 대신 쓰자)  
> yum check-update -- 업데이트 가능 패키지 출력  
> yum update 패키지 -- 해당 패키지 업데이트, install을 사용하면 설치되있을경우 자동 업데이트  
> yum remove 패키지  -- 패키지 삭제  
> yum info 패키지 -- 패키지 정보  
> yum clean all -- 기존 저장소 목록 지우기  

### 웹서버/php/db 설치

**\* php 7.2 설치 세팅**  
> wget https://dl.fedoraproject.org/pub/epel/epel-release-latest-7.noarch.rpm  
> rpm -Uvh epel-release-latest-7.noarch.rpm  
> wget http://rpms.remirepo.net/enterprise/remi-release-7.rpm  
> rpm -Uvh remi-release-7.rpm  
> yum install -y yum-utils  
> yum-config-manager --enable remi-php72  

> yum install httpd php mariadb php-mysql -- 설치  
> systemctl enable httpd -- 부팅시 자동시작  
> systemctl enable mariadb -- db 서비스 등록  
> systemctl start httpd -- 서버 시작  
> systemctl start mariadb -- db 시작  
> systemctl status httpd -- 서비스 상태 확인  
> systemctl disable 서비스이름 // 서비스 자동시작 삭제  
> systemctl list-unit-files

### 아파치 php연동
**\* vi /etc/httpd/conf/httpd.conf**  
> \<IfModule mime_module>  
> 하위에  
> AddType application/x-httpd-php .html .htm .php .inc  
> AddType application/x-httpd-php-source .phps  
> 추가한다

### 방화벽 관련
> firewall-config -- 설정창 열기(x-windows)  
> firewall-cmd --permanent --add-service=http  // 서비스 추가  
> firewall-cmd --permanent --remove-service=http // 서비스 삭제  
> firewall-cmd --reload // 다시로드  
> firewall-cmd --permanent --add-port=8080/tcp // 포트 추가  
> firewall-cmd --permanent --add-port=4000-4100/tcp // 포트 범위 추가  
> firewall-cmd --permanent --remove-port=8080/tcp // 포트 삭제  
> firewall-cmd --permanent --add-source=192.168.1.0/24 --add-port=22/tcp // 192.168.1 ~ 대역에서 ssh접근허용  
> firewall-cmd --permanent --new-zone=webserver // 새로운 존생성  
> firewall-cmd --set-default-zone=webserver // webserver존 활성화  
> firewall-cmd --permanent --add-forward-port=port=80:proto=tcp:toport=9000 // 포트포워딩
> 설정파일 /etc/firewalld/zones/public.xml

**\* 위 명령에서 해당 존에 설정을 컨트롤 하려면 permanent 이후에 --zone=public 와 같이 붙여준다(public존)**  
> firewall-cmd --list-services --zone=public  -- 리스트 보기

### jdk11 설치
> amazon corretto11 버전 rpm 파일 다운후  
> sudo yum localinstall 파일이름  
> java -version // 제대로 설치됬는지 확인  
> which java // 자바위치  
> readlink -f 자바위치 // 실제경로  
> vi /etc/profile  
> export JAVA_HOME=/usr/lib/jvm/java-11-amazon-corretto 입력 후 저장  

### 톰캣9 설치
> 이것 역시 톰캣사이트에서 tar.gz파일 받음  
> tar xvzpf 파일이름  
> sudo mv 풀린폴더이름 /opt  
> cd /opt; mv 풀린폴더 tomcat  
> sudo useradd tomcat  (그룹자동생성)
> sudo chown -R tomcat:tomcat /opt/tomcat  

**\* 권한설정 제대로 안되면 서비스 실행 안됨**  
> 톰캣폴더/conf/server.xml 파일 수정 -> port 및 인코딩 설정  
> port="9000" URIEncoding="UTF-8" 추가  
> 톰캣 실행 오류시 보통 server.xml 실수가 많음  
> "나 태그< />확인!!   
> web.xml에서 세션시간 세팅
> sudo firewall-cmd --permanent --zone=public --add-port=9000/tcp  
> sudo firewall-cmd --reload  

### 서비스 자동실행 등록
**\* sudo vi /etc/systemd/system/tomcat.service**

-------------------------------------------------------------

> \# Systemd unit file for tomcat  
> [Unit]  
> Description=Apache Tomcat Web Application Container  
> After=syslog.target network.target    
>   
> [Service]  
> Type=forking  
>   
> Environment=JAVA_HOME=/usr/lib/jvm/java-11-amazon-corretto  
> Environment=CATALINA_HOME=/opt/tomcat  
> Environment=CATALINA_BASE=/opt/tomcat  
> Environment=CATALINA_PID=/opt/tomcat/temp/tomcat.pid  
> ExecStart=/opt/tomcat/bin/startup.sh  
> ExecStop=/opt/tomcat/bin/shutdown.sh  
>   
> User=tomcat  
> Group=tomcat  
> RestartSec=10  
> Restart=always  
>   
> [Install]  
> WantedBy=multi-user.target  

-----------------------------------------------------------

### user role 추가(안쓰면할필요x)
**\* vi conf/tomcat-users.xml**

-----------------------------------------------------------
> \<role rolename="manager-gui"/>  
> \<role rolename="manager-script"/>  
> \<role rolename="manager-status"/>  
> \<role rolename="admin-gui"/>  
> \<user username="아이디" password="비번"   
> roles="manager-gui,manager-script,manager-status,admin-gui"/>  

> 아래는 적용안해도 되는듯하다
> /opt/tomcat/webapps/manager/META-INF/context.xml  
> /opt/tomcat/webapps/host-manager/META-INF/context.xml  
> 두 파일에서 \<value allow="^.*$"/> 다른거 삭제하지말고 allow 값만 변경  
-----------------------------------------------------------

> sudo systemctl daemon-reload  
> sudo systemctl enable tomcat  
> sudo systemctl start tomcat  

### web.xml 수정
> 에러페이지 컨트롤 
> 스프링부트에서 적용되는 errorcontroller가 톰캣에서는 web.xml에서 처리됨
> 같은 방향으로 처리하기 위해 /error로 보냄
```
<error-page>
    <error-code>400</error-code>
    <location>/WEB-INF/jsp/error/404.jsp</location>
</error-page>
<error-page>
    <error-code>403</error-code>
    <location>/WEB-INF/jsp/error/404.jsp</location>
</error-page>
<error-page>
    <error-code>404</error-code>
    <location>/WEB-INF/jsp/error/404.jsp</location>
</error-page>
<error-page>
    <error-code>500</error-code>
    <location>/WEB-INF/jsp/error/404.jsp</location>
</error-page>
<error-page>
    <exception-type>java.lang.Throwable</exception-type>
    <location>/WEB-INF/jsp/error/error.jsp</location>
</error-page>
```

> 세션 만료 수정   
``` 
<session-config>
    <session-timeout>30</session-timeout>
</session-config>
```

### 마리아디비 설치
**\* vi /etc/yum.repos.d/MariaDB.repo**

------------------------------------------------------

> [mariadb]  
> name = MariaDB  
> baseurl = http://yum.mariadb.org/10.4/centos8-amd64   
> module_hotfixes = 1   
> gpgkey = https://yum.mariadb.org/RPM-GPG-KEY-MariaDB  
> gpgcheck = 1  

------------------------------------------------------

**\* 저장 후 설치**  
sudo yum clean all  
sudo yum install MariaDB-server MariaDB-client

**\* 설치후**
```
vi /etc/my.cnf
[mysqld]
log-error=/var/log/mysql/error.log
log-warnings = 2
character_set_server = utf8

[mysqldump]
default-character-set=utf8

[mysql]
default-character-set=utf8

저장 후 재실행
해당 폴더가 없다면 만들고 mysql 사용자 및 그룹지정
```

설정 생략


**\* 저장후**

> sudo systemctl enable mariadb  
> sudo systemctl start mariadb  
> firewall-cmd --permanent --zone=public --add-service=mysql (3306포트)  
> sudo firewall-cmd --reload  

> mysql_upgrade -u root // 아래 명령 실행시 db존재하지 않느다는 오류시 사용  
> sudo mysql_secure_installation // 보안설정 암호외에 전부다 엔터  

**\* 계정생성**
> create user '아이디'@'%' identified by '비밀번호';  
> grant all privileges on *.* to '아이디'@'%';  
> flush privileges;  

### PowerOff Button으로 전원오프
>sudo yum install acpid
>vi /etc/systemd/logind.conf  해당 내용 주석 제거후 재시작

### DB 백업 스케줄
>sudo vi /usr/local/bin/dbbackup.sh 스크립트 파일 생성 
```
#!/bin/bash

# 변수선언
DATE=$(date +"%Y%m%d")
BACKUP_DIR=~/dbbackup

# 3달 전 백업 삭제
find  $BACKUP_DIR/ -mtime +90 -name '*.sql' -exec rm {} \;

# 백업 진행
mysqldump -u 사용자 -p비번 database명 > $BACKUP_DIR/db_$DATE.sql

#DB여러개
mysqldump -u 사용자 -p비번 --databases db1 db2 > $BACKUP_DIR/db_$DATE.sql

#원격백업
mysqldump -u 사용자 -p비번 -h ip주소 -P 포트넘버 --databases db1 db2 > $BACKUP_DIR/db_$DATE.sql
```
>chmod 755 /usr/local/bin/dbbackup.sh 권한변경
>crontab -e  ---->  00 12 * * * /usr/local/bin/dbbackup.sh 저장, 12시마다 스크립트 실행
>crontab -l 리스트보기
>권한없는 폴더로 설정시 문제발생 미리 테스트 후 등록

### 새 하드웨어 추가
>sudo fdisk -l 디스크 리스트 확인
>sudo fdisk /dev/sd* sda sdb등 리스트에서 확인 후 해당 디스크 입력
>파티션 설정 후 sudo mkfs.xfs 혹은 mkfs.ext4 /dev/sd*1 (sdb1 sdb2 등) 포맷
>sudo blkid에서 uuid 확인 및 복사
>sudo vi /etc/fstab
>UUID=UUID실제값 마운트디렉토리 파티션 포맷 defaults 0 0
>예시 UUID=w123412938472037423 /sub_hard xfs defaults 0 0
>x-window에서 유틸리티->디스크에서 설정가능

### centos8 시간동기화(문제가 있는거 같음 테스트요망)
>yum install chrony 이미 설치되있을꺼임
>vi /etc/chrony.conf -> 서버풀변경 ntppool.org/zone/kr에서 확인
>sudo systemctl start chronyd
>sudo systemctl enable chronyd
>timedatectl set-ntp yes -> 싱크활성화
>timedatectl status -> 동기화 확인
>chronyc sources -> 기준서버 확인

### cockpit 시스템 모니터링
> sudo systemctl start cockpit  
> sudo systemctl enable cockpit.socket  
> 해당 아이피 :9090으로 접속 후 관리    

### 로그 용량 관리
> sudo vi /etc/logrotate.d/tomcat   
``` 
/opt/tomcat/logs/catalina.out {
    copytruncate
    compress
    daily
    rotate 60
    missingok
    notifempty
    dateext
}
```
> 실행테스트 sudo logrotate -f /etc/logrotate.d/tomcat  
> sudo vi /etc/logrotate.d/mysql-error
```
/var/log/mysql/error.log {
    copytruncate
    compress
    create 644 mysql mysql
    daily
    rotate 60
    missingok
    notifempty
    dateext
}
```

### 백신 설치
> sudo yum install epel-release 
> sudo yum install clamav clamav-update 
> freshclam 업데이트실행    
> clamscan -옵션    

### ip차단 첫번째 방법
> /iplist 폴더 생성
> 폴더안에 wget http://www.ipdeny.com/ipblocks/data/countries/all-zones.tar.gz   
> 오류시 --no-check-certificate 플래그 추가후 다운  
> tar -vxzf all-zones.tar.gz    
> firewall-cmd --permanent --new-ipset=blacklist --type=hash:net     
>   --option=family=inet --option=hashsize=4096 --option=maxelem=200000    
> firewall-cmd --permanent --ipset=blacklist --add-entries-from-file=/iplist/cn.zone    
> 개별적으로 추가시 firewall-cmd --permanent --ipset=blacklist --add-entry=해당아이피
> firewall-cmd --reload
> firewall-cmd --permanent --add-rich-rule='rule source ipset=blacklist drop' 
> 삭제시    
> firewall-cmd --permanent --delete-ipset=blacklist 
> firewall-cmd --permanent --zone=public --remove-rich-rule='rule source ipset=blacklist drop'  

### ip차단 두번째 방법
> https://www.maxmind.com/에서 GeoLite2 Country: CSV Format파일 받음    
> GeoLite2-Country-Locations-en.csv, GeoLite2-Country-Blocks-IPv4파일을 복사해온다  
```
#!/bin/bash 

#국가명 
CONTRY="CN" 

#geolite2 국가번호위치 
LOCATION=~/GeoLite2-Country-Locations-en.csv 

#geolite2 ipv4위치 
DATA=~/GeoLite2-Country-Blocks-IPv4.csv 

#firewall 수정할xml파일위치 
FIREWALL=/etc/firewalld/zones/public.xml 

#국가번호를 따서 code에 저장 
CODE=`egrep ${CONTRY} ${LOCATION} | cut -d, -f1 | sed -e 's/"//g' | sed -e 's/,/-/g'` 

#firewall xml파일 수정 스크립트 
sed -i '/<\/zone>/d' ${FIREWALL} 
for IPRANGE in `egrep "${CODE}" $DATA | cut -d, -f1 | sed -e 's/"//g' | sed -e 's/,/-/g'` 
do 
echo -e " <rule family=\"ipv4\"> 
    <source address=\"${IPRANGE}\"/> 
    <drop/> 
  </rule>" >> ${FIREWALL} 
done 
echo -n "</zone>" >> ${FIREWALL}
```
> ipblock_CN.sh 위에 내용으로 스크립트 생성 
> sudo sh ipblock_CN.sh 실행하면 public.xml에 ip룰 추가
> firewall-cmd --reload(30초정도)   

### fail2ban (로그인실패시 밴처리)
> yum install fail2ban fail2ban-systemd  
> systemctl start fail2ban  
> cp /etc/fail2ban/jail.conf /etc/fail2ban/jail.local   
> vi /etc/fail2ban/jail.local 수정  
```
# 차단하지 않을 IP
ignoreip = 127.0.0.1/8

# 시간동안 차단
bantime  = 5000h

# 입력한 시간 내에 허용횟수를 초과하여 실패시 차단하게 됩니다.
findtime  = 1h

# 최대 허용 횟수
maxretry = 5

# 메일 수신자, 다중 수신자는 지원 안 함 
destemail = sysadmin@example.com

# 메일 보낸 사람
sender = fail2ban@my-server.com

# 메일 전송 프로그램
mta = sendmail

# 차단시 whois 정보와 관련 로그를 첨부하여 메일 전송
# whois사용시 yum install whois
action = %(action_mwl)s
# 알림메일 전송받지 않음
#action = %(action_)s

# 밴처리 등록
- firewalld 사용시
banaction = firewallcmd-multiport
banaction_allports = firewallcmd=allports
- iptables 사용시
banaction = iptables-multiport
banaction_allports = iptables=allports
** 모든 포트 차단시 위아래 전부 올포트로 설정하면된다.

# sshd 서비스 차단
[sshd]
enabled = true
port     = ssh, 2020 
# 포트를 2개 이상 사용하면 제대로 등록되지 않는다

[mysqld-auth]
port = 3306
logpath = /var/log/mysql/error.log
backend = polling
enabled = true
```
> 적용후 서비스 리스타트  
> 상태확인 sudo fail2ban-client status  
> 밴해제 sudo fail2ban-client unban 해당 아이파 혹은 --all  
> 밴등록 제대로 적용됬는데 확인 sudo iptables -nL 

### Docker 사용하기
> sudo yum config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo    
> sudo yum list docker-ce --showduplicates | sort -r    
> repo등록은 생략해도 될듯    
> 20.08.11 현재 centos8은 오류 뜰텐데 --nobest옵션 붙여주고 설치 
> sudo yum install docker-ce    
> docker 서비스 등록 및 시작    
> docker -v 혹인 docker version 입력해서 확인   
> docker사용시 sudo 권한 필요 sudo usermod -aG docker $USER 사용자를 추가해줘도 됨 
> 추후 계속 ... 

### postfix 사용 (연동실패)
> sudo yum install postfix mailx cyrus-sasl 
> sudo yum remove sendmail  
> sudo vi /etc/postfix/main.cf
```
relayhost = [smtp.gmail.com]:587
smtp_use_tls = yes 
smtp_sasl_auth_enable = yes 
smtp_sasl_security_options = noanonymous 
#smtp_tls_CAfile = /etc/ssl/certs/ca-bundle.crt
smtp_sasl_password_maps = hash:/etc/postfix/gmail
```
> sudo alternatives --config mta  // mta 변경   
> mailq // 메일 큐 확인 
> postsuper -d ALL or postsuper -d ALL deferred // 메일큐비우기 

### https 적용하기
> sudo dnf install certbot  
> sudo certbot certonly --standalone -d 도메인  
> certbot certonly --manual -d  *.도메인 -d 도메인 --preferred-challenges dns-01 
> --server https://acme-v02.api.letsencrypt.org/directory // 와일드 카드적용	
> 80 , 443(?) 포트열어줘야 인증가능함   
> /etc/letsencrypt/live/도메인/chain.pem  
> /etc/letsencrypt/live/도메인/privkey.pem  
> /etc/letsencrypt/live/도메인/cert.pem 
> 상태확인 certbot certificates 
> 갱신 certbot renew    
> sudo certbot revoke --cert-path /etc/letsencrypt/archive/도메인/cert1.pem 폐기
> tomcat conf/server.xml 설정   
```
    <Connector port="8080" protocol="HTTP/1.1"
               URIEncoding="UTF-8"
               connectionTimeout="20000"
               redirectPort="443" />

    <Connector port="8443"
               protocol="org.apache.coyote.http11.Http11NioProtocol"
               maxThreads="150"
               SSLEnabled="true"
               URIEncoding="UTF-8">
        <UpgradeProtocol className="org.apache.coyote.http2.Http2Protocol" />
        <SSLHostConfig>
            <Certificate certificateKeyFile="/etc/letsencrypt/live/도메인/privkey.pem"
                         certificateFile="/etc/letsencrypt/live/도메인/cert.pem"
                         certificateChainFile="/etc/letsencrypt/live/도메인/chain.pem"
                         type="RSA" />
        </SSLHostConfig>
    </Connector>
```
> sudo chmod 755 /etc/letsencrypt/live  
> sudo chmod 755 -R /etc/letsencrypt/archive   
> tomcat conf/web.xml 리다이렉트 설정   
```
    <security-constraint>
      <web-resource-collection>
        <web-resource-name>SSL Forward</web-resource-name>
        <url-pattern>/*</url-pattern>
      </web-resource-collection>
      <user-data-constraint>
        <transport-guarantee>CONFIDENTIAL</transport-guarantee>
      </user-data-constraint>
    </security-constraint>
    
    <!-- 특정 url패턴은 http동시 사용가능
    <security-constraint>
      <web-resource-collection>
        <web-resource-name>HTTPS or HTTP</web-resource-name>
        <url-pattern>/images/*</url-pattern>
        <url-pattern>/css/*</url-pattern>
      </web-resource-collection>
      <user-data-constraint>
        <transport-guarantee>NONE</transport-guarantee>
      </user-data-constraint>
	</security-constraint>
    -->
```
> 톰캣 재시작 후 접속 테스트    
> 3개월 만료이므로 갱신 등록해야함 1개월전부터 가능하므로 나중에 테스트 

### 톰캣서버 argument 추가
> 톰캣폴더/bin/setenv.sh
```
#!/bin/sh
export JAVA_OPTS="$JAVA_OPTS\
 --add-opens java.base/jdk.internal.misc=ALL-UNNAMED\
 -Dio.netty.tryReflectionSetAccessible=true"
```

### OS설치시 nvme 오류해결
> 부팅전 quiet 뒤에 nvme_core.default_ps_max_latency_us=5500 추가후 Ctrl+x	
> 설치 후 sudo vi /etc/default/grub	
> GRUB_CMDLINE_LINUX 가장뒤에 위변수 추가 후 저장	
> sudo grub2-mkconfig -o /boot/grub2/grub.cfg	
> 재부팅후 cat /sys/module/nvme_core/parameters/default_ps_max_latency_us 확인	

### 노트북 랜카드 설치관련

> rtl8821ce 무선랜이 잡히지 않아서 관련 드라이브를 설치해야한다
>
> https://github.com/lwfinger/rtw88 참고