import { Injectable } from '@angular/core';

import { MenuNode } from '../models/menu.node';
import { FlattenedNode } from '../models/flattened.node'

@Injectable()
export class TreeNodeConverter {

    public create(node: MenuNode, level: number): FlattenedNode {    
        return  {
            expandable: node.children && node.children.length > 0,
            name: node.name,
            topic: node.topic,
            year: node.year,
            month:  node.month,
            article:  node.article,
            level: level,
            count: node.count
        };
    }

    public level(node: FlattenedNode): number {    
        return node.level;
    }

    public expandable(node: FlattenedNode): boolean {    
        return node.expandable;
    }

    public children(node: MenuNode): MenuNode[] {    
        return node.children;
    }
}
