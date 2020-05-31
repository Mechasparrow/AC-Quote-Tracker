
import io
from bs4 import BeautifulSoup
import json

def grabVillagerHtml():
    f = open("assets/villager-list.html", "r")
    html = f.read()
    return html

def parseHtmlInput(html):
    soup = BeautifulSoup(html, 'html.parser')
    return soup

def saveData(filename, data):
    with open(filename, 'w') as outfile:
        json.dump(data, outfile)


def main():
    soup = parseHtmlInput(grabVillagerHtml())
    rows = soup.select("#mw-content-text > table:nth-child(4) > tbody > tr:nth-child(2) > td > table > tbody")[0]


    kids = list(rows.children)
    
    data = []

    idx = 0
    for kid in kids:
        record = dict()

        if idx ==0:
            idx+=1
            continue 
        try:
            img = list(kid.children)[2].select("a")[0]
            name = list(kid.children)[1].select("a")[0]
            
            record["name"] = name["title"]
            record["img"] = img["href"]
            data.append(record)
        except:
            pass
        idx+=1
    
    print(data)
    saveData("out.json", data)
if __name__ == "__main__":
    main()