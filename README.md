# SwitchAcc
Switch Acccounting<br />

<b>Известные проблемы:</b><br />
Целостность данных сейчас поддерживается базой данных. При попытке удалить модель, на которую ссылается коммутатор - база данных вернет отказ. Приложение вернет ошибку. То же для VLAN;<br />
При увеличении количества моделей, для удобства, необходимо сделать отдельную страницу выбора. Сейчас реализовано простым select;<br />
Детальная реализация моделей коммутаторов и VLAN;<br />
Обработка даты не установленного еще коммутатора;<br />
Доработка UI "по вкусу";<br />
Все строки в ресурсы, для локализации (при необходимости);<br />
При добавлении или удалении модели (VLAN, коммутатора) возвращаться на актуальную страницу;<br />
Валидацию обсудить и переделать. Сейчас проверка при добавлении коммутатора на стороне клиента и сервера. При добавлении модели и VLAN на стороне клиента и на уровне свойств с выбросом исключения;<br />
Фильтры не реализованы из-за ограничения по времени выполнения работы (просто не успел);<br />
Так же фильтры на страницах с моделями и VLAN.<br />
