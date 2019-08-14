### selinux 해제
>sudo gedit /etc/sysconfig/selinux (gedit <-> vi)  
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

### 고정아이피 등록 
>vi /etc/sysconfig/network-scripts/ifcfg-eth0 // 뒤에 이름은 다를수 있다  
>BOOTPROTO="static"  
>IPADDR="192.168.0.150"  
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

>systemctl daemon-reload // 설정파일 재시작  
>systemctl enable vncserver@:1.service // 서비스 활성화  
>vncserver // 서비스 시작 첫 시작시 접속할 비번입력  
>vncpasswd // 패스워드 변경  
>방화벽 포트 열어주고 5901~5903정도 열어줌 (서비스 vnc-server선택함)  
>클라이언트에 vncviewer설치후 아이피:포트로접속  

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
> useradd 사용자 -- 사용자 추가 // -u 1111 --사용자아이디1111 // -g 그룹1 -- 그룹1에 포함(그룹1존재해야함) // -d /newhome -- 홈디텍토리 /newhome으로  
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
> firewall-cmd --premanent --new-zone=webserver // 새로운 존생성  
> firewall-cmd --set-default-zone=webserver // webserver존 활성화  

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
> sudo useradd tomcat  
> sudo groupadd tomcat  
> sudo chown -R tomcat:tomcat tomcat  

**\* 권한설정 제대로 안되면 서비스 실행 안됨**  
> 톰캣폴더/conf/server.xml 파일 수정 -> port 및 인코딩 설정  
> port="9000" URIEncoding="UTF-8" 추가  
> 톰캣 실행 오류시 보통 server.xml 실수가 많음  
> "나 태그< />확인!!   
> sudo firewall-cmd --permanent --zone=public --add-port=9000/tcp  
> sudo firewall-cmd --reload  

### 서비스 자동실행 등록
**\* sudo vi /etc/systemd/system/tomcat.service**

-------------------------------------------------------------

> \# Systemd unit file for tomcat  
> [Unit]  
> Description=Apache Tomcat Web Application Container  
> After=syslog.target  
>   
> [Service]  
> Type=forking  
>   
> Environment=JAVA_HOME=/usr/lib/jvm/java-11-amazon-corretto  
> Environment=CATALINA_HOME=/opt/tomcat  
> Environment=CATALINA_BASE=/opt/tomcat  
>   
> ExecStart=/opt/tomcat/bin/startup.sh  
> ExecStop=/opt/tomcat/bin/shutdown.sh  
>   
> User=tomcat  
> Group=tomcat  
> WMask=0007  
> RestartSec=10  
> Restart=always  
>   
> [Install]  
> WantedBy=multi.user.target  

-----------------------------------------------------------

### user role 추가
**\* vi conf/tomcat-users.xml**

-----------------------------------------------------------
> \<role rolename="manager-gui"/>  
> \<role rolename="manager-script"/>  
> \<role rolename="manager-status"/>  
> \<role rolename="admin-gui"/>  
> \<user username="아이디" password="비번"   
> roles="manager-gui,manager-script,manager-status,admin-gui"/>  
> 
-----------------------------------------------------------

> /opt/tomcat/webapps/manager/META-INF/context.xml  
> /opt/tomcat/webapps/host-manager/META-INF/context/xml  
> 두 파일에서 \<value allow="^.*$/> 다른거 삭제하지말고 allow 값만 변경  
> sudo systemctl daemon-reload  
> sudo systemctl enable tomcat  
> sudo systemctl start tomcat  

### 마리아디비 설치
**\* vi /etc/yum.repos.d/MariaDB.repo**

------------------------------------------------------

> [mariadb]  
> name = MariaDB  
> baseurl = http://yum.mariadb.org/10.4/contos7-amd64  
> gpgkey=https://yum.mariadb.org/RPM-GPG-KEY-MariaDB  
> gpgcheck=1  

------------------------------------------------------

**\* 저장 후 설치**  
sudo yum install MariaDB-server MariaDB-client

**\* 설치후**
vi /etc/my.cnf

------------------------------------------------------

> [mysqld]  
> init_connect="SET collation_connection = utf8_general_ci"    
> init_connect="SET NAMES utf8"   
> character-set-server = utf8  
> collation-server = utf8_general_ci  
>   
> [client]  
> default-character-set = utf8  
>   
> [mysqldump]  
> default-character-set = utf8  
>   
> [mysql]  
> default-character-set = utf8  

---------------------------------------

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