### 도커/쿠버네티스

- CentOs에서 Docker 설치방법

> sudo yum install yum-utils
>
> // repo 추가
>
> sudo yum-config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo
>
> // 리파지토리에서 사용가능 버전 나열 및 정렬
>
> sudo yum list docker-ce --showduplicates | sort -r
>
> // docker 설치(버전 생략시 최신버전사용)
>
> sudo yum install docker-ce[버전] docker-ce-cli[버전] containerd.io
>
> ** centos8기준 설치 오류 발생시 --allowerasing 또는 --nobest붙여준다
>
> ** docker-ce만 설치해도 나머지 알아서 설치됨
>
> // docker 실행
>
> sudo systemctl start docker



- Docker 제거

> sudo yum remove docker-ce docker-ce-cli containerd.io
>
> // 이미지,컨테이너,볼륨 삭제
>
> sudo rm -rf /var/lib/docker
>
> sudo rm -rf /var/lib/containerd



- Docker권한 부여 (sudo 없이 사용) * 그냥도 sudo 없이 잘되는거 같은데??

> sudo groupadd docker
>
> sudo usermod -aG docker $USER
>
> -> 재로그인



- Docker 자동 시작

> sudo systemctl enable docker
>
> sudo systemclt enable containerd



### 이미지 관련 명령

- 이미지 목록

> docker images



- 검색

> docker search <이미지이름>
>
> **--limit** [숫자]: 검색건수 제한 



- 이미지 받기

> docker pull <이미지이름>:[버전]
>
> 버전 -> latest 를 쓰면 최신 버전을 받는다



- 받은 이미지 목록

> docker image ls



- 이미지 태그 달기

> docker image tag 기반이미지명[:태그] 새이미지명[:태그]
>
> latest에 태그를 달면 latest와 해당 태그 모두 같은 이미지를 가리킨다



- 이미지 생성

> docker build [옵션] <DockerFile경로>
>
> **-t**  : 태그 (거의 필수)
>
> **-f** : Dockerfile 명이 다를 경우 지정 할 때 사용
>
> **--pull=true** : 베이스 이미지 새로 받아옴



- 이미지 삭제

> docker rmi <이미지아이디>
>
> **-f** : 컨테이너도 강제 삭제



- 이미지 올리기

> docker image push [option] 리포지토리명[:태그]





### 컨테이너 관련 명령

- 컨테이너 목록 보기

> docker ps
>
> **-a** : 모든 컨터에니 목록 출력



- 생성 및 실행

> create 와 start를 한번에 처리
>
> 사용법 : docker [container] run 옵션 
>
> docker run [options] image[:TAG|@DIGEST] [COMMAND] [ARG...]
>
> container run 의 단축형으로 컨테이너를 실행한다
>
> 주요 옵션으로는 
>
> **-d** : 백그라운드 실행
>
> **-it** : i(stdin활성)와 t(tty모드,bash사용)옵션 같이사용 터미널 입력을 컨테이너로 전달하기위한 옵션
>
> **-e** : 환경 변수 옵션
>
> **--name** : 컨테이너 이름 지정
>
> **-p** : 포트포워딩, 외부포트:내부포트 식으로 지정
>
> **-v**  : 볼륨 설정
> <컨테이너 디렉터리> 예) -v /data
>
> <호스트 디렉터리>:<컨테이너 디렉터리> 예) -v /data:/data 
>
> <호스트 디렉터리>:<컨테이너 디렉터리>:<ro, rw> 예) -v /data:/data:ro 
>
> <호스트 파일>:<컨테이너 파일> 예) -v /var/run/docker.sock:/var/run/docker.sock
>
> **-w** : 컨테이너 내 기본workdir 지정
>
> **--entrypoint** : Dockerfile의 entrypoint를 오버라이드
>
> **--rm** : 프로세스 종료시 컨테이너 자동 제거



- 시작

> docker start <컨테이너 id 또는 name>



- 재시작

> docker restart <컨테이너 id 또는 name>



- 접속

> docker attach <컨테이너 id 또는 name>



- 정지

> docker stop <컨테이너 id 또는 name>
>
> - Bash Shell에서 `exit` 또는 `Ctrl + D`를 입력하면 컨테이너가 정지된다.
> - `Ctrl + P`, `Ctrl + Q`를 차례대로 입력하여 컨테이너를 정지하지 않고, 컨테이너에서 빠져나온다.



- 삭제

> docker rm <컨테이너id 또는 name>
>
> // 모든 컨테이너 삭제
>
> sudo docker rm 'docker ps -a -q' 



- 로그확인

> docker container logs -t <컨테이너식별자>



- 쉘 접속

> docker exec -it <container-name or id> /bin/bash



### Dockerfile 명령어

> \- FROM 베이스 이미지 지정
>
> \- RUN 명령 실행 : shell형식, exec형식 (이미지를 작성하기 위해 실행하는 명령)
>
> \- CMD컨테이너 실행 명령 (Dockerfile 안에서는 하나의 명령만 가능, 우선적인 명령이 있을 시 덮어짐)
>
> \- LABEL 라벨 설정
>
> \- EXPOSE 포트 익스포트
>
> \- ENV 환경변수
>
> \- ADD 파일/디렉토리 추가 (ADD <호스트파일경로> <Docker 이미지의 파일 경로>)
>
> \- COPY 파일 복사 (COPY <호스트파일경로> <Docker 이미지의 파일 경로>)
>
> \- ENTRYPOINT 컨테이너 실행 명령 (다른 명령이 있어도 같이 쓰임)
>
> \- VOLUME 볼륨마운트
>
> \- USER 사용자 지정
>
> \- WORKDIR 작업 디렉토리
>
> \- ARG Dcokerfile 안의 변수
>
> \- ONBUILD 빌드 완료 후 실행되는 명령
>
> \- STOPSIGNAL 시스템 콜 시그널 설정
>
> \- HEALTHCHECK 컨테이너의 헬스 체크
>
> \- SHELL 기본 쉘 설정





