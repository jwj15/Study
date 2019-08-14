### 상단바 없애기
- `<window>` 태그 안에 'WindowStyle'추가  
None -> 없음, ToolWindow -> x 버튼 나오는 상단바  
AllowsTransparency="True" -> 상단짤리는것 해결.. 이유는 모름
- 추가적으로  
WindowState="Maximized" -> 전체화면으로 실행  
ResizeMode="NoResize" -> 크기 재설정 불가
### String Format
- TextBlock의 경우 Binding 안에 stringformat옵션을 주지만  
 Label의 경우 ContentStringFormat라는 태그로 설정한다.
 ### DataContext해제
 - 같은 ViewModel을 사용하는 경우 Window.Close()하여도 남아있는 경우가 있다.
  왤까?  
  어쨋든 그로인해 발생하는 문제는 DataContext = null로 해결  
  Close()전에 해줘도 되고 Window생성자에 Closed이벤트에 추가해주어도 된다  
`Closed += (o, e) => { DataContext = null; };`
### Style/BasedOn
- Style을 설정할때 기존값을 불러오려면 BasedOn태그에 소스를 설정.  
  적용되있는 값을 그대로 가져오려면 {StaticResource {x:Type Button}}처럼 불러온다.
###  RelativeSource
- Binding할때 소스의 위치를 상대적으로 설정할경우 사용  
- 부모요소의 값 가져오기  
`{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Width}`  
`{TemplateBinding Width}`  
- 두 가지 방식의 차이점  
TemplateBinding이 더 가볍지만 TwoWay지원X, Freezable클래스 속성(brush,pen등) 지원X  
- 한단계 위에 해당 타입의 소스를 바인딩하는 경우  
`{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListBox}}, Path=Tag}`  
- 두단계 위에 해당 타입의 소스 바인딩  
`{Binding RelativeSource={RelativeSource AncestorType={x:Type StackPanel}, AncestorLevel=2}, Path=Orientation}`
### 줄바꿈
- &#10 또는 &#xA 사용
### foreach 문제
- 컬렉션에 foreach사용 할 경우 수정,삭제 시 오류 발생  
이런 경우 for문을 사용하면 된다.
