   M S B A M L   `   `   `  ����A  =Diplom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Diplom.Resources.View.Windows.Handlers&Diplom.Resources.View.Windows.Handlers  5      <    6Diplom.Resources.View.Windows.Handlers.ActivityHandler   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      @local4clr-namespace:Diplom.Resources.View.Windows.Handlers  5        N� Title$  ActivityHandler��5
       � 	Resources 5         MyBoolToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �   BackgroundWindow#��[ 6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��0.17* �6   .+�5   
   �� 
������� �� CornerRadius$ 20��6$   
������ $��20q�6P    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      	Direction$	 -90Q�63      RenderingBias$ Quality=�6C   	   ShadowDepth$		 0.5Q�6[   5      �� 5!   
   
�������$ 20��6$   
������ $��20q�6P   ._�5"      �� .+�5#      �� $��	10 3 10 0q�6   .+�5$      �� 
 �� Orientation$
 
Horizontal=�6!   .+�5%      �� $��*��6    
���  ��$��25��6=   $��30(�6H   6X   �� 5&      $��Название:��6    $	��150��64   $��20(�6C   6S   5'      �� 5(      -   5        $��textBox��5(      $	��225��6-    % !MaterialDesignFloatingHintTextBox#��[ 6<   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$6 0Введите название конкурса��6w   ��6�   �� *Activity.name+5)      �� 5*      $��	10 3 10 0q�6   .+�5+      �� $
 
Horizontal=�6!   .+�5,      �� $��*��6    
���  ��$��25��6=   $��30(�6H   6X   �� 5-      $��	Дата:��6    $	��150��60   $��20(�6?   6O   5.      (  "System.Windows.Controls.DatePicker  5/      $��30��6!      Text$ Введите дату��6-   $	��220��6A   $0 *Выберите дату конкурса��6P      SelectedDate 6�   �� *Activity.date+50      �� 51      $��	10 3 10 0q�6   .+�52      �� $
 
Horizontal=�6!   .+�53      �� $��*��6    
���  ��$��25��6=   $��30(�6H   6X   �� 54      $��Результат:��6    $	��150��65   $��20(�6D   6T   55      �� 56      -   5        $��PlaceTextBox��56      #��[ 62   $. (Введите ваш результат��6m   $	��225��6�   ��6�   �� *Activity.place+57      �� 58      $��	10 3 10 0q�6   .+�59      �� $
 
Horizontal=�6!   .+�5:      �� $��*��6    
���  ��$��25��6=   $��30(�6H   6X   �� 5;      $��Тип:��6    $	��150��6/   $��20(�6>   6N   5<      �� 5=        MaterialDesignComboBox#���  6   $��13(�6P   $
��10 8q�6^   $	��220��6m   $��Center=�6|    �� DisplayMemberPath$
 name��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6  ��6�   �� *ActivityTypes+ �� SelectedItem 6�   �� *Activity.activityType+6  5>      �� 5?      $��	10 3 10 0q�6   .+�5@      �� $
 
Horizontal=�6!   .+�5A      �� $��*��6    
���  ��$��25��6=   $��30(�6H   6X   �� 5B      $��Уровень:��6    $	��150��63   $��20(�6B   6R   5C      �� 5D      #���  6   $��13(�6P   $
��10 8q�6^   $	��220��6m   $��Center=�6|   $
 name��6�   $
 TrueY�6  ��6�   �� *ActivityLevels+ 6�   �� *Activity.activityLevel+6  5E      5F      5G      �� 5I   
   
�������$��1��6$   $ 20��64   
������ $��20q�6`    5J        5K      $ 10Q�6#   $	 -90Q�63   $ Quality=�6C   $		 0.5Q�6[   5M      �� 5O   
   
�������$��1��6$   $ 20��64   
������ $��20q�6`   ._�5P      �  5Q      �� 5R      $��50 �6$   �� 5S      $��* �6$   .+�5V      �� $
 
Horizontal=�6   $��Center=�66   $��0 10 0 0q�6S   .+�5W      �� $��*��6   
���  ��$��25��69   $��30(�6D   6T   �� 5X      $(��"Выбор изображения:��6   $	��150��69   $��20(�6H   6X   5Y      �� 5[      -   5        $��ImageButton��5[   X     ImageButton#��[ 6   $��1��6?   $��10q�6L   .��5\      �� -   5        $��ActivityImage��5\   A   ��6   �� *Activity.imageURL+6A   5]      5_      5`      �� 5b   
   -   5        $��	AddButton��5b      $��1��6   $��2��6/   $	��150��6C   $��40��6O     CornerButton#��[ 6[   $��Добавить��6�   $��20(�6�   $��0 0 0 10q�6�   6�   �� 5c   
   -   5        $��
EditButton��5c      $��1��6   $��2��60   $	��150��6D   $��40��6P   #��[ 6\   $��Изменить��6�   $��20(�6�   $��0 0 0 10q�6�   $y�	Collapsed=�6�   6�   5d      5e      