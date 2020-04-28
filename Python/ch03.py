help(print) # print함수 도움말 호출

from tkinter import *

# 캔버스 관련 라이브러리 사용 예제
canvas_height = 400
canvas_width = 600
canvas_colour = "black"

window = Tk()
window.title("Title ...")
canvas = Canvas(bg = canvas_colour, height = canvas_height, width = canvas_width, highlightthickness=0)
canvas.pack()

window.mainloop()