import urllib2  # the lib that handles the url stuff
import csv

data = urllib2.urlopen("https://raw.githubusercontent.com/clarketm/proxy-list/master/proxy-list.txt").read(20000) # it's a file like object and works just like a file
data = data.split("\n")
list = ''

for line in data: # files are iterable
    if len(line)>1:
        if line[0].isdigit():
            if "-S" in line:
                list += "HTTPS://" + line.rsplit(' ')[0] + \n
            else:
                list += "HTTP://" + line.rsplit(' ')[0] + \n
                

with open("Butts.txt", "w") as text_file:
    text_file.write(list)