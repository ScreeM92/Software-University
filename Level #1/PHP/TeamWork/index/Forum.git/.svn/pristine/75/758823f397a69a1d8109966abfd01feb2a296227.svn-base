function BBCode($txt){
	$replace=preg_replace('/\[B\](.*?)\[\/B\]/', '<strong>$1</strong>', $txt);
	$replace=preg_replace('/\[IMG=(.*?) width=(.*?)\]\[\/IMG\]/', '<img class="imgsFromPost" alt="imgFromPost" style="width: $2" src="$1" />', $replace);
	$replace=preg_replace('/\[IMG=(.*?)\]\[\/IMG\]/', '<img class="imgsFromPost" alt="imgFromPost" style="width: 30%" src="$1" />', $replace);
	$replace=preg_replace('/\[I\](.*?)\[\/I\]/', '<em>$1</em>', $replace);
	$replace=preg_replace('/\[U\](.*?)\[\/U\]/', '<span style="text-decoration: underline">$1</span>', $replace);
	$replace=preg_replace('/\[COLOR=(.*?)\](.*?)\[\/COLOR\]/', '<span style="color: $1">$2</span>', $replace);
	$replace=preg_replace('/\[SIZE=(.*?)\](.*?)\[\/SIZE\]/', '<span style="font-size: $1px">$2</span>', $replace);
	$replace=preg_replace('/\[URL=(.*?)\](.*?)\[\/URL\]/', '<a href="$1">$2</a>', $replace);
	$replace=str_replace('\n', '<br />', $replace);
	return $replace;
}
