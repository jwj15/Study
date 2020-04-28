'''자료형'''

# 튜플 - 콤마로 구분, 인덱스 0부터 시작, 값 변경 불가
my_tuple = ("one", "two", "three", 4, True)
print(my_tuple)
print(my_tuple[1])

# 리스트 - 튜플과 유사하지만 값 변경 가능
my_list = ["ont", "two", "three", 4, False]
print(my_list)
print(my_list[0])
my_list[0] = "one"
print(my_list[0])

# 사전 - json 형식과 유사 
my_dic = {1:"one", 2:"two", 3:"three", "4":4, "True":True}
print(my_dic)
print(my_dic[1]) # 괄호안에 인덱스가 아닌 키값입력
print(my_dic["True"])