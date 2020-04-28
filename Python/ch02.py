import random

randomValue = random.randint(1,5)

if randomValue == 1:
    print("하")
elif randomValue == 2:
    print("하하")
elif randomValue == 3:
    print("하하하")
elif randomValue == 4:
    print("하하하하")
else:
    print("하하하하하")

# 값 입력 받기
name = input("이름입력: ")
print("입력값",name)

# 함수 정의
def count(number):
    n = 1
    result = ""
    while n <= number:
        result += "*"
        n += 1
    return result

print(count(10))

def times_tables(number):
    n = 1
    while n < 10:
        print(number," X ", n, " = " ,n*number)
        n += 1

times_tables(int(input("출력할 구구단 >"))) # 입력값은 문자라서 숫자형으로 변환 숫자외 입력시 오류